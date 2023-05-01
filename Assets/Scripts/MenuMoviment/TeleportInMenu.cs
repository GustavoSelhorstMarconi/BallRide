using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInMenu : MonoBehaviour
{
    public GameObject targetTeleport;
    public Vector3 offset;

    public void OnCollisionEnter(Collision other)
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

        if (other.gameObject.CompareTag("Player")) {
            Renderer playerRenderer = other.gameObject.GetComponent<Renderer>();

            other.transform.position = targetTeleport.transform.position + offset;
            playerRenderer.material.color = color;
        }
    }
}