using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovment : MonoBehaviour
{

    public bool canMove;
    public float noteSpeed = 5/60f;
    public Vector3 noteDirection = Vector3.forward;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(noteDirection * noteSpeed * Time.deltaTime);
        }
    }
}