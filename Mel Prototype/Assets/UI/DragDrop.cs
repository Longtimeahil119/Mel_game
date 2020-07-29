using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : EventTrigger
{

    private bool dragging;
    private Vector2 original;
    public int grandParentSlot;
    public int collidedWith;

    

    private GameObject slot;

    // Start is called before the first frame update
    void Start()
    {
        int.TryParse(transform.parent.parent.gameObject.name, out grandParentSlot);
        original = new Vector2(transform.position.x, transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.parent.parent.SetAsLastSibling();
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            transform.position = original;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {

        dragging = false;

        if (Inventory.invSlots[collidedWith].Equals(""))
        {
            Inventory.invSlots[collidedWith] = Inventory.invSlots[grandParentSlot];
            Inventory.invSlots[grandParentSlot] = "";
            Inventory.invStacks[collidedWith] = Inventory.invStacks[grandParentSlot];
            Inventory.invStacks[grandParentSlot] = 0;
        }
        else
        {
             
        }

        // Fix visual bug here somewhere?
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int.TryParse(other.gameObject.name, out collidedWith);
    }

    private void OnTriggerExit(Collider other)
    {
    }

}
