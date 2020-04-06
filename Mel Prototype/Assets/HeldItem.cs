using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    private GameObject[] barIconsCopy = new GameObject[5];

    public GameObject[] heldItems;
    private string selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        //barIconsCopy = new GameObject[ActionBar.arrays["barIcons"].Length];
    }

    // Update is called once per frame
    void Update()
    {
        //print(ActionBar.arrays["barIcons"].Length);
        ActionBar.arrays["barIcons"].CopyTo(barIconsCopy, 0);
        try
        {
            if (barIconsCopy[ActionBar.slotSelected - 1].transform.gameObject.GetComponent<UnityEngine.UI.Image>().IsActive())
                selectedItem = barIconsCopy[ActionBar.slotSelected - 1].transform.gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name;
            else
                selectedItem = "";
        }
        catch
        {
            selectedItem = "";
        }
        

        print(selectedItem);

        if (selectedItem.Equals("Gun"))
            heldItems[0].SetActive(true);
        else
            heldItems[0].SetActive(false);

        if (selectedItem.Equals("Flashlight"))
            heldItems[1].SetActive(true);
        else
            heldItems[1].SetActive(false);
        
    }
}
