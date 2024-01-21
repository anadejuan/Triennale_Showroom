using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Components; // Add the appropriate namespace for WeArt components

public class Drop_object : MonoBehaviour
{
    public GameObject linked_object;

    private void OnTriggerEnter(Collider other)
    {
        if (linked_object != null)
        {
            if (other.gameObject.name == linked_object.name)
            {
                other.gameObject.transform.SetParent(transform, false);
                other.gameObject.transform.localPosition = transform.GetChild(0).transform.localPosition;
                other.gameObject.transform.eulerAngles = transform.GetChild(0).transform.eulerAngles;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<MeshRenderer>() != null && child.gameObject.name != linked_object.name)
                    {
                        child.GetComponent<MeshRenderer>().enabled = false;
                    }
                }

                // Check if the linked object has WeArtTouchableObject component
                WeArtTouchableObject touchableObject = linked_object.GetComponent<WeArtTouchableObject>();
                if (touchableObject != null)
                {
                    // Set the Graspable property to false
                    touchableObject.Graspable = false;
                }
            }
        }
    }
}