using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    private GameObject[] barIconsCopy = new GameObject[5];

    public GameObject[] heldItems;
    public static string selectedItem;
    
    private GameObject itemPre;

    private List<string> droppableItems;

    // Start is called before the first frame update
    void Start()
    {
        droppableItems = new List<string>();

        droppableItems.Add("Cube");

        var cube = Resources.Load("Cube Variant");
        itemPre = cube as GameObject;
        Instantiate(itemPre, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        ActionBar.arrays["barIcons"].CopyTo(barIconsCopy, 0);
        try
        {
            if (barIconsCopy[ActionBar.slotSelected - 1].transform.gameObject.GetComponent<UnityEngine.UI.Image>().IsActive())
            {
                selectedItem = barIconsCopy[ActionBar.slotSelected - 1].transform.gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name;
                
            }
            else
                selectedItem = "";
        }
        catch
        {
            selectedItem = "";
        }


        if (selectedItem.Equals("Gun"))
            heldItems[0].SetActive(true);
        else
            heldItems[0].SetActive(false);

        if (selectedItem.Equals("Flashlight"))
            heldItems[1].SetActive(true);
        else
            heldItems[1].SetActive(false);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (droppableItems.Contains(selectedItem))
            {
                if(Inventory.invStacks[15 - ActionBar.slotSelected] > 0)
                {
                    var cube = Resources.Load(selectedItem);
                    itemPre = cube as GameObject;
                    GameObject obj = Instantiate(itemPre, transform.position, transform.rotation);
                    obj.name = selectedItem;

                    Inventory.invStacks[15 - ActionBar.slotSelected] -= 1;
                }
                
                if(Inventory.invStacks[15 - ActionBar.slotSelected] == 0)
                {
                    Inventory.invSlots[15 - ActionBar.slotSelected] = "";
                }
                
            }
        }

    }

    public static void pickUpItem(string item, GameObject obj)
    {
        bool hasItem = false;
        int index = 0;
        int firstEmptyIndex = 0;
        bool determinedStack = false;
        bool determinedEmpty = false;
        // First we check to see if the picked up item already exists within the inventory
        for(int i = 0; i < Inventory.invSlots.Length; i++)
        {
            if (Inventory.invSlots[i].Equals(item))
            {
                // Stack the item
                hasItem = true;
                index = i;
                determinedStack = true;
                break;
            }
            else if (Inventory.invSlots[i].Equals("") && !determinedEmpty)
            {
                firstEmptyIndex = i;
                determinedEmpty = true;
            }
        }

        // If it found somewhere to stack, index will stay the same
        // If it found an empty slot and a stack was not found, index becomes firstEmptyIndex
        if(determinedEmpty && determinedStack == false)
        {
            index = firstEmptyIndex;
        }
        else if (determinedEmpty == false && determinedStack == false)
        {
            print("INV FULL??");
        }

        if(hasItem)
        {
            Inventory.invStacks[index] += 1;
            Destroy(obj);
        }
        else
        {
            Inventory.invSlots[index] = item;
            Destroy(obj);
            Inventory.invStacks[index] += 1;
        }

    }

}
