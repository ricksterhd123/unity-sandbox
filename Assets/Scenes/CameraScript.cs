using System;
using System.Collections.Generic;
using UnityEngine;


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
    // Main camera object
    public Camera camera;
    // BoxCollider object which stops camera from clipping into walls.
    public BoxCollider collider;

    // Camera pitch & yaw
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    void Start()
    {
        collider.transform.parent = camera.transform;
        farClipPlaneDistance = camera.farClipPlane;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Camera starting...");
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        // Get input and move camera position
        if (Input.GetButton(forwardBtnName))
        {
            camera.transform.position = camera.transform.position + camera.transform.forward * moveSpeed;
        }                                                                                               
        if (Input.GetButton(backwardBtnName))                                                           
        {                                                                                               
            camera.transform.position = camera.transform.position - camera.transform.forward * moveSpeed;
        }                                                                                               
        if (Input.GetButton(leftBtnName))                                                               
        {                                                                                               
            camera.transform.position = camera.transform.position - camera.transform.right * moveSpeed;
        }                                                                                               
        if (Input.GetButton(rightBtnName))                                                              
        {                                                                                               
            camera.transform.position = camera.transform.position + camera.transform.right * moveSpeed;
        }
    }
}