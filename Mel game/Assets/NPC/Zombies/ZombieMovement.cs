using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombieMovement : MonoBehaviour
{
    public GameObject Player;
    public float movementSpeed = 6;


    void start()
    {

    } 

    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}