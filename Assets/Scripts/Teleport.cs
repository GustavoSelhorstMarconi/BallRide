using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetTeleport;
    public Vector3 offset;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = targetTeleport.transform.position + offset;
            FindObjectOfType<AudioManager>().PlaySound("Portal");
        }
    }
}
