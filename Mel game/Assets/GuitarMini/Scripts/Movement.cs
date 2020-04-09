using UnityEngine;


public class Movement : MonoBehaviour
{
    public float Speed = 0f;
    public bool canMove;
    public float jumpForce = 0f;

    CharacterController Player;

    private bool hasJumped;

    float moveLR;

    float vertVelocity;

    void Start()
    {
        Player = GetComponent<CharacterController>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            moveLR = Input.GetAxis("Horizontal") * Speed;

            Vector3 movement = new Vector3(moveLR, vertVelocity, 0);

            Player.Move(movement * Time.deltaTime);
        }
        
        if (!canMove)
        {
            Vector3 movement = new Vector3(0, vertVelocity, 0);

            Player.Move(movement * Time.deltaTime);
        }

        //Jumping
        if (Input.GetButton("Jump") && canMove)
        {
            hasJumped = true;
        }

        ApplyGravity();
    }

    //Gravity
    private void ApplyGravity()
    {
        if (Player.isGrounded == true)
        {
            if (!hasJumped)
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