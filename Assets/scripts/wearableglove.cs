using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class WearableGlove : MonoBehaviour
{
    [Header("Attach points on the glove model")]
    public Transform leftHandAttach;
    public Transform rightHandAttach;

    [Header("Lock after wearing")]
    public bool lockAfterWear = true;

    private XRGrabInteractable grab;
    private Rigidbody rb;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Recommended defaults for stability
        grab.movementType = XRBaseInteractable.MovementType.Kinematic;

        grab.selectEntered.AddListener(OnSelectEntered);
        grab.selectExited.AddListener(OnSelectExited);
    }

    void OnDestroy()
    {
        grab.selectEntered.RemoveListener(OnSelectEntered);
        grab.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor == null) return;

        // Decide left/right (works in most XR rigs by name)
        string n = interactor.transform.name.ToLower();
        bool isLeft = n.Contains("left");
        Transform targetAttach = isLeft ? leftHandAttach : rightHandAttach;

        if (targetAttach == null)
        {
            Debug.LogWarning("WearableGlove: Attach transform is missing.");
            return;
        }

        // IMPORTANT: prevent XR Grab from fighting offsets
        grab.useDynamicAttach = false;

        // Snap: set the grab attachTransform BEFORE XR updates pose
        grab.attachTransform = targetAttach;

        // Stop physics so it behaves like worn
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.detectCollisions = false;

        // Optional: lock it so user can't drop it
        if (lockAfterWear)
        {
            // Keep it following the hand via parenting done by XR Grab
            // Then disable grab to prevent detach
            grab.enabled = false;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Only used if lockAfterWear = false (so you can remove it)
        if (lockAfterWear) return;

        // Restore physics when released
        rb.detectCollisions = true;
        rb.isKinematic = false;
        rb.useGravity = false; // keep off unless you want it to fall when dropped
    }
}


