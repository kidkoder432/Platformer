using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerBody;
    private bool spaceIsPressed;
    private float horizontalInput;
    private bool canJump = true;
    [SerializeField] private Transform GroundCheckTransfrom;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceIsPressed = true;

        }

        //Get the horizontal input (from a keyboard, mouse, or joystick) for moving the player
        horizontalInput = Input.GetAxis("Horizontal");
    }
    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        int playerLeftRightSpeedMultiplier = 3;
        // Check if the player is on the ground
        if (Physics.OverlapSphere(GroundCheckTransfrom.position, 0.1f).Length == 1)
        {
            playerLeftRightSpeedMultiplier = 2;
            canJump = false;
        }

        else
        {
            canJump = true;
        }

        // Make the player jump
        if (spaceIsPressed && canJump)
        {
            playerBody.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            spaceIsPressed = false;
        }

        //Move the player horizontally
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput * playerLeftRightSpeedMultiplier, playerBody.velocity.y, 0);

        if (playerBody.position.y < -5){
            transform.position = new Vector3(0, 2, 0);
        }
    }


}
