using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRestart : MonoBehaviour
{
    public GameObject loseEffect;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Lose");
            StartCoroutine(GameManager.RestartLevelEffect(other.gameObject, loseEffect));
        }
    }
}