using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [Header("Move values")]
    public Vector3 direction;
    public float speed;

    [Header("Push values")]
    public Vector3 directionPush;
    public float speedPush;

    private Rigidbody rigidBody;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PushMovement();
            PushPlayer(other);
        }
    }

    private void PushMovement()
    {
        rigidBody.AddForce(direction * speed, ForceMode.Impulse);
    }

    private void PushPlayer(Collision other)
    {
        Rigidbody otherRigidBody = other.gameObject.GetComponent<Rigidbody>();
        otherRigidBody.AddForce(directionPush * speedPush, ForceMode.Impulse);

        // if(other.gameObject.GetComponent<MobileControlMovement>())
        // {
        //     other.gameObject.GetComponent<MobileControlMovement>().SetIsGrounded(false);
        // }

        // if(other.gameObject.GetComponent<ControlMovement>())
        // {
        //     other.gameObject.GetComponent<ControlMovement>().SetIsGrounded(false);
        // }
    }
}