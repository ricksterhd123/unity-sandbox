using System;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    none,
    forward,
    backward,
    left,
    right
}

class CameraScript : MonoBehaviour
{
    // Camera movement speed factor
    public float moveSpeed { get; set; } = 0.5f;
    // Camera rotation speed factor
    public float rotateSpeed { get; set; } = 1.5f;
    public String forwardBtnName { get; set; } = "Forward";
    // Axis name for moving forward
    public String backwardBtnName { get; set; } = "Back";
    // Axis name for moving back
    public String leftBtnName { get; set; } = "Left";
    // Axis for moving right
    public String rightBtnName { get; set; } = "Right";
    // BoxCollider object which stops camera from clipping into walls.

    // Camera pitch & yaw
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    private Direction lastDirection;

    void Start()
    {
        lastDirection = Direction.none;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Camera starting...");
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Get input and move camera position
        if (Input.GetButton(forwardBtnName))
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            lastDirection = Direction.forward;
        }                                                                                               
        if (Input.GetButton(backwardBtnName))                                                           
        {                                                                                               
            transform.position = transform.position - transform.forward * moveSpeed * Time.deltaTime;
            lastDirection = Direction.backward;
        }                                                                                               
        if (Input.GetButton(leftBtnName))                                                               
        {                                                                                               
            transform.position = transform.position - transform.right * moveSpeed * Time.deltaTime;
            lastDirection = Direction.left;
        }                                                                                               
        if (Input.GetButton(rightBtnName))                                                              
        {                                                                                               
            transform.position = transform.position + transform.right * moveSpeed * Time.deltaTime;
            lastDirection = Direction.right;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        Debug.Log("collision detected");
    }
    
}