using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public string interactButton;

    public float interactDistance = 3f;
    public LayerMask interactLayer;

    public Image interactIcon;

    public GameObject panel;

    public bool isInteracting;

    void Start()
    {
        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if(isInteracting == false)
            {

                panel.SetActive(true);

                if(Input.GetButtonDown(interactButton))
                {
                    if(hit.collider.CompareTag("DoorOpen"))
                    {
                        hit.collider.GetComponent<DoorOpen>().ChangeDoorState();
                    }
                    if(hit.collider.CompareTag("Cube"))
                    {
                        HeldItem.pickUpItem(hit.collider.gameObject.name, hit.collider.gameObject);
                        
                    }
                }
            }
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
