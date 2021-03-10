// using UnityEngine;

// public class CameraController : MonoBehaviour
// {

//     private float moveSpeed = 0.5f;
//     private float scrollSpeed = 10f;

//     void Update()
//     {
//          if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
//          {
//              transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//          }

//          if (Input.GetAxis("Mouse ScrollWheel") != 0)
//          {
//              transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
//          }


//     }

// }



using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}