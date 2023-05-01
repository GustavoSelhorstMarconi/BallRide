using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPushObstacle : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRigidBody = other.gameObject.GetComponent<Rigidbody>();

            otherRigidBody.AddForce(direction * speed, ForceMode.Impulse);
        }
    }
}
