using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraTarget;
    public float sensibility;
    [Range(0, 360)]
    public float limitRotation;

    float rotX;
    float rotY;

    void Start()
    {
        transform.forward = cameraTarget.forward;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse Y");
        float mouseY = Input.GetAxis("Mouse X");

        rotX -= mouseX * sensibility * Time.deltaTime;
        rotY += mouseY * sensibility * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -limitRotation, limitRotation);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    void LateUpdate()
    {
        if(cameraTarget)
        {
            transform.position = cameraTarget.position;
        }
    }
}