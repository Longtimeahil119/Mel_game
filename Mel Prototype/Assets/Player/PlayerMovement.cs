using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Varables
    public float Speed = 0f;
    public float WalkSpeed = 6f;
    public float SprintSpeed = 10f;
    public float CrouchSpeed = 4f;
    public float RotationSpeed = 2f;
    public float jumpForce = 4f;
    public GameObject eyes;

    CharacterController Player;

    private bool hasJumped, isSprinting, isCrouched;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;

    float vertVelocity;

    void Start()
    {
        Speed = WalkSpeed;
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        //look movement
        moveFB = Input.GetAxis("Vertical") * Speed;
        moveLR = Input.GetAxis("Horizontal") * Speed;

        rotX = Input.GetAxis("Mouse X") * RotationSpeed;
        rotY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);
        transform.Rotate(0, rotX, 0);

        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        Player.Move(movement * Time.deltaTime);

        //Jumping
        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        //Sprinting
        if (Input.GetButtonDown("Sprint"))
        {
            if (isSprinting == false)
            {
                isSprinting = true;
                Speed = SprintSpeed;
            }
            else
            {
                isSprinting = false;
                Speed = WalkSpeed;
            }
        }

        //Crouching
        if (Input.GetButtonDown("Crouch"))
        {
            if (isCrouched == false)
            {
                Player.height = Player.height / 2;
                isCrouched = true;
                isSprinting = false;
                Speed = CrouchSpeed;
            }
            else
            {
                Player.height = Player.height * 2;
                isCrouched = false;
                Speed = WalkSpeed;
            }
        }

        ApplyGravity();
    }

    //Gravity
    private void ApplyGravity()
    {
        if (Player.isGrounded == true)
        {
            if (hasJumped == false)
            {
                vertVelocity = Physics.gravity.y;

            }
            else
            {
                vertVelocity = jumpForce;
            }
        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }

    }
}