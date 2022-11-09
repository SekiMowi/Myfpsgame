using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{   
    //Variables
    public float mouseSensivity = 100f;
    public Slider sliderMouse;
    private float cameraXRotation = 0f;
 

    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        //Hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Getting mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        //Bases mouses y axis rotation with cameras x axis rotation
        cameraXRotation -= mouseY;
        //Clamps the camera that it can't go over 90 decrees and lower than -90 on the X axis
        cameraXRotation = Mathf.Clamp(cameraXRotation, -90, 90);
        //Rotates the camera with Y axis mouse movement
        transform.localRotation = Quaternion.Euler(cameraXRotation, 0, 0);
        //Rotates the player with X axis mouse movement
        playerBody.Rotate(Vector3.up * mouseX);
    }
    public void AdjustSens(float NewSens)
    {
        mouseSensivity = NewSens;
    }
}
