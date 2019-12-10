using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    // Available slots
    int[] invSlots = new int[12];
    bool showInventory = false;
    float windowAnimation = -1;
    float animationTimer = 0;

    int itemIndexToDrag = -1;
    Vector2 dragOffset = Vector2.zero;

    PlayerMovement player;
    public GameObject panel;
    Texture temp;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //panel.gameObject.SetActive(false);

        for (int i = 0; i < invSlots.Length; i++)
        {
            invSlots[i] = -1;
        }

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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            //showHidePanel();

        }

        if(animationTimer <= 1)
        {
            animationTimer += Time.deltaTime;
        }

        if(showInventory)
        {
            //windowAnimation = Mathf.Lerp(windowAnimation, 1f, animationTimer);
            PlayerMovement.playerMovement.canMove = false;
        }
        else
        {
            //windowAnimation = Mathf.Lerp(windowAnimation, 0.0f, animationTimer);
            PlayerMovement.playerMovement.canMove = true;
        }

    }

    public void showHidePanel()
    {
        if (showInventory)
            panel.gameObject.SetActive(false);
        else
            panel.gameObject.SetActive(true);
    }

}
