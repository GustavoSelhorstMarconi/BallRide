using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraControl : MonoBehaviour
{
    public Transform cameraTarget;
    public float sensibility;
    [Range(0, 360)]
    public float limitRotation;
    public TouchField touchField;

    float cameraAngleX;
    float cameraAngleY;
    float cameraAngleSpeed = 0.2f;

    void Start()
    {
        transform.forward = cameraTarget.forward;
    }

    void Update()
    {
        cameraAngleX -= touchField.touchDistance.y * cameraAngleSpeed;
        cameraAngleY += touchField.touchDistance.x * cameraAngleSpeed;

        cameraAngleX = Mathf.Clamp(cameraAngleX, -limitRotation, limitRotation);

        transform.rotation = Quaternion.Euler(cameraAngleX, cameraAngleY, 0);
    }

    void LateUpdate()
    {
        if (cameraTarget)
        {
            transform.position = cameraTarget.position;
        }
    }
}