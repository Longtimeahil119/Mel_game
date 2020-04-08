using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    private GameObject[] barIconsCopy = new GameObject[5];

    public GameObject[] heldItems;
    private string selectedItem;
    
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

        // First we check to see if the picked up item already exists within the inventory
        for(int i = 0; i < Inventory.invSlots.Length - 1; i++)
        {
            if (Inventory.invSlots[i].Equals(item))
            {
                // Stack the item
                Inventory.invStacks[i] += 1;
                print(i);
                Destroy(obj);
                
                break;
            }
            else if (Inventory.invSlots[i].Equals(""))
            {
                Inventory.invSlots[i] = item;
                Destroy(obj);
                Inventory.invStacks[i] += 1;
                break;
            }
        }

    }
}
