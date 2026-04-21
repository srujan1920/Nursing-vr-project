using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FoleySnapOnRelease : MonoBehaviour
{
    public Transform snapPoint;

    private bool isPlaced = false;
    private GameObject currentFoley;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlaced) return;

        GameObject rootObj = other.transform.root.gameObject;

        if (rootObj.CompareTag("Foley"))
        {
            currentFoley = rootObj;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlaced) return;

        GameObject rootObj = other.transform.root.gameObject;

        if (rootObj.CompareTag("Foley") && rootObj == currentFoley)
        {
            currentFoley = null;
        }
    }

    public void TrySnap()
    {
        if (isPlaced) return;
        if (currentFoley == null) return;
        if (snapPoint == null) return;

        XRGrabInteractable grab = currentFoley.GetComponent<XRGrabInteractable>();
        Rigidbody rb = currentFoley.GetComponent<Rigidbody>();

        currentFoley.transform.position = snapPoint.position;
        currentFoley.transform.rotation = snapPoint.rotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (grab != null)
        {
            grab.enabled = false;
        }

        isPlaced = true;
    }
}