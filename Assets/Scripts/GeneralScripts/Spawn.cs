using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 direction;
    public float speed;
    public float time;

    void Start()
    {
        InvokeRepeating("SpawnObject", time, time * 2);
    }

    void SpawnObject()
    {
        GameObject cloneObject = Instantiate(spawnObject, transform.position, Quaternion.identity);
        if (transform.parent.gameObject.GetComponent<Collider>() != null)
        {
            Physics.IgnoreCollision(cloneObject.GetComponent<Collider>(), transform.parent.gameObject.GetComponent<Collider>());
            // Physics.IgnoreCollision(cloneObject.GetComponent<Collider>(), transform.parent.Find("Base").gameObject.GetComponent<Collider>());
        }
        Rigidbody rigidBodyObject = cloneObject.GetComponent<Rigidbody>();

        rigidBodyObject.velocity = direction * speed;
    }
}