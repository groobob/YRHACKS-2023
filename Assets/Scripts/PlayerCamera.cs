using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    float rotationX;
    float rotationY;

    private void Start()
    {
        // locking your cursor and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Getting the mouse x and y input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * sensY * 10;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.smoothDeltaTime * sensX * 10;

        // Setting rotation variables based on mouse input
        rotationX -= mouseY;
        rotationY += mouseX;

        // Sets a rotation interval for the y rotation on the camera
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotating the camera and player
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
