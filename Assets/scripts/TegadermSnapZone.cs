using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TegadermSnapZone : MonoBehaviour
{
    public Transform snapPoint;

    private XRGrabInteractable currentTegaderm;
    private bool canSnap = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tegaderm"))
        {
            currentTegaderm = other.GetComponent<XRGrabInteractable>();
            canSnap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tegaderm"))
        {
            canSnap = false;
            currentTegaderm = null;
        }
    }

    public void TrySnap()
    {
        if (canSnap && currentTegaderm != null)
        {
            Rigidbody rb = currentTegaderm.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            currentTegaderm.transform.position = snapPoint.position;
            currentTegaderm.transform.rotation = snapPoint.rotation;
            currentTegaderm.transform.SetParent(snapPoint);

            currentTegaderm.enabled = false;
        }
    }
}
