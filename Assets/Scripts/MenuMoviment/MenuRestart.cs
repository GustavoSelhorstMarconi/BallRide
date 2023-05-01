using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRestart : MonoBehaviour
{
    public Transform startPosition;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = startPosition.position;
        }
    }
}