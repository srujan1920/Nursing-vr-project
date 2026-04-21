using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CannulaSnapZone : MonoBehaviour
{
    public Transform snapPoint;

    private XRGrabInteractable currentCannula;
    private bool canSnap = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cannula"))
        {
            currentCannula = other.GetComponent<XRGrabInteractable>();

            if (currentCannula == null)
            {
                currentCannula = other.GetComponentInParent<XRGrabInteractable>();
            }

            if (currentCannula != null)
            {
                canSnap = true;
                Debug.Log("Cannula entered snap zone");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cannula"))
        {
            canSnap = false;
            currentCannula = null;
            Debug.Log("Cannula left snap zone");
        }
    }

    public void TrySnap()
    {
        if (canSnap && currentCannula != null)
        {
            Rigidbody rb = currentCannula.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = currentCannula.GetComponentInParent<Rigidbody>();
            }

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            currentCannula.transform.SetParent(snapPoint, false);
            currentCannula.transform.localPosition = Vector3.zero;
            currentCannula.transform.localRotation = Quaternion.identity;

            currentCannula.enabled = false;

            Debug.Log("Cannula snapped successfully");
        }
        else
        {
            Debug.Log("Cannula snap failed");
        }
    }
}
