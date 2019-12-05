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

    Texture temp;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
        }

        if(animationTimer <= 1)
        {
            animationTimer += Time.deltaTime;
        }

        if(showInventory)
        {
            windowAnimation = Mathf.Lerp(windowAnimation, 1f, animationTimer);
            PlayerMovement.playerMovement.canMove = false;
        }
        else
        {
            windowAnimation = Mathf.Lerp(windowAnimation, 0.0f, animationTimer);
            PlayerMovement.playerMovement.canMove = true;
        }

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 200, 50), "Press 'Tab' to open Inventory");

        Debug.Log(windowAnimation);

        // showInventory causes it to disappear before animation finishes
        // find a way to fix it so the small black box doesn't show or
        // find a way to let the animation finish etc etc
        if(windowAnimation <= 1 && showInventory)
        {
            GUILayout.BeginArea(new Rect(430 , Screen.height / 6, (430 * windowAnimation),(430 * windowAnimation)), GUI.skin.GetStyle("box"));

            GUILayout.Label("Inventory", GUILayout.Height(25));

            GUILayout.BeginVertical();
            for(int i = 0; i < invSlots.Length; i+=3)
            {
                GUILayout.BeginHorizontal();

                for(int a = 0; a < 3; a++)
                {
                    if(invSlots[i + a] > -1)
                    {
                        //GUILayout.Box(temp, GUILayout.Width(95));
                    }
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }

}
