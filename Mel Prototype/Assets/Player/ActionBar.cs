using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{

    public GameObject panel;

    // Size set in Action Bar inspector
    public GameObject[] slots;
    public Sprite iconSprite;
    public Sprite iconSelectedSprite;

    public GameObject[] barIcons;
    public static Dictionary<string, GameObject[]> arrays;

    public static int slotSelected;

    // Start is called before the first frame update
    void Start()
    {
        slotSelected = 1;

        arrays = new Dictionary<string, GameObject[]>
        {
            { "barIcons", barIcons }
        };

    }

    // Update is called once per frame
    void Update()
    {
        SetActionInactive();
        DetermineActive();

        //slots[slotSelected - 1].SetActive(true);
        slots[slotSelected - 1].GetComponent<Image>().sprite = iconSelectedSprite;

        //Check bottom row of inventory
        for (int i = Inventory.invSlots.Length - 5; i < Inventory.invSlots.Length; i++)
        {
            
            if (Inventory.invSlots[i].Equals("")){
                barIcons[i - (Inventory.invSlots.Length - 5)].SetActive(false);
            }
            else
            {
                barIcons[i - (Inventory.invSlots.Length - 5)].SetActive(true);
                barIcons[i - (Inventory.invSlots.Length - 5)].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Items/"+Inventory.invSlots[i].ToString());
            }
        }

    }

    void SetActionInactive()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[slotSelected - 1].GetComponent<UnityEngine.UI.Image>().sprite = iconSprite;
        }
    }

    void DetermineActive()
    {
        if(Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            slotSelected = 1;
        }
        if (Input.GetKeyDown("2") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            slotSelected = 2;
        }
        if (Input.GetKeyDown("3") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            slotSelected = 3;
        }
        if (Input.GetKeyDown("4") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            slotSelected = 4;
        }
        if (Input.GetKeyDown("5") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            slotSelected = 5;
        }
    }

}
