using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRestart : MonoBehaviour
{
    public GameObject loseEffect;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GameManager.RestartLevelEffect(other.gameObject, loseEffect));
            FindObjectOfType<AudioManager>().PlaySound("Lose");
        }
    }
}