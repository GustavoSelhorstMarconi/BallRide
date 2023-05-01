using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject explosion;
    public GameObject loseEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.FireBallRestartLevel(other.gameObject, loseEffect);
            FindObjectOfType<AudioManager>().PlaySound("Lose");
            // StartCoroutine(GameManager.RestartLevelEffect(other.gameObject, loseEffect));
        }
        else
        {
            Destroy(gameObject);
            GameObject explosionObject = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionObject, 0.2f);
        }
    }
}