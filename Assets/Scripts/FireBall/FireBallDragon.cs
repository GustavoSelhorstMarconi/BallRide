using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDragon : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 direction;
    public float speed;

    private Rigidbody rigidBodyObject;

    void Start()
    {
        rigidBodyObject = GetComponent<Rigidbody>();
        rigidBodyObject.velocity = direction * speed;      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.RestartLevel();
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
