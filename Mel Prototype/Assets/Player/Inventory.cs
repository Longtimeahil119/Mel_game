using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{

    // Available slots
    public static string[] invSlots = new string[15];
    public bool showInventory = false;
    float windowAnimation = -1;
    float animationTimer = 0;

    int itemIndexToDrag = -1;
    Vector2 dragOffset = Vector2.zero;

    public GameObject panel;
    // Size set in inspector
    public GameObject[] imageIcons;
    Texture temp;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        panel.gameObject.SetActive(false);
        showInventory = false;

        for(int i = 0; i < invSlots.Length; i++)
        {
            invSlots[i] = "";
        }

        invSlots[0] = "Cube";
        invSlots[10] = "Gun";
        invSlots[11] = "Flashlight";
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            showInventory = !showInventory;
            animationTimer = 0;

            if (showInventory)
            {
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            }

            showHidePanel();

        }

        if(animationTimer <= 1)
        {
            animationTimer += Time.deltaTime;
        }

        if(showInventory)
        {
            PlayerMovement.playerMovement.canMove = false;
            Gun.gun.canFire = false;
        }
        else
        {
            
            PlayerMovement.playerMovement.canMove = true;
            Gun.gun.canFire = true;
        }

        ShowAllItems();


    }

    public void showHidePanel()
    {
        if (showInventory)
            panel.gameObject.SetActive(true);
        else
            panel.gameObject.SetActive(false);
    }

    public void ShowAllItems()
    {
        for(int i =0; i < invSlots.Length; i++)
        {
            if(invSlots[i].Equals(""))
            {
                imageIcons[i].SetActive(false);
            }
            else
            {
                imageIcons[i].SetActive(true);
                imageIcons[i].GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Items/"+invSlots[i].ToString());
                //print("Items/" + invSlots[i].ToString() + ".png");
            }
        }
    }

}
