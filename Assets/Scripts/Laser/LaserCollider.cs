using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    public GameObject loseEffect;
    public GameObject cutPlayer;

    // void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         GameManager.CallLaserRestartLevel(other.gameObject, cutPlayer);
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.CallLaserRestartLevel(other.gameObject, cutPlayer);
            FindObjectOfType<AudioManager>().PlaySound("Laser");
        }
    }
}