using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public Vector3 rotation;
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
