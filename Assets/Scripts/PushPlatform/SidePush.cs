using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePush : MonoBehaviour
{
    [Header("Configuration values")]
    public Color onCollisionColor;

    [Header("Push values")]
    public Vector3 directionPush;
    public float speedPush;

    private Color startColor;

    void Start()
    {
        startColor = gameObject.GetComponent<Renderer>().material.color;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PushPlayer(other);
            StartCoroutine(ChangeColor());
        }
    }

    private void PushPlayer(Collision other)
    {
        Rigidbody otherRigidBody = other.gameObject.GetComponent<Rigidbody>();
        otherRigidBody.AddForce(directionPush * speedPush, ForceMode.Impulse);

        if(other.gameObject.GetComponent<MobileControlMovement>())
        {
            other.gameObject.GetComponent<MobileControlMovement>().SetIsGrounded(false);
        }

        if(other.gameObject.GetComponent<ControlMovement>())
        {
            other.gameObject.GetComponent<ControlMovement>().SetIsGrounded(false);
        }
    }

    private IEnumerator ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = onCollisionColor;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Renderer>().material.color = startColor;
    }
}