using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    public Rigidbody rigidBody { get; private set; }
    private bool isGrounded = true;
    // public Vector3 movementX;
    // public Vector3 movementZ;
    // public Vector3 jump;

    // public float jumpSpeed = 15f;
    public float movementSpeed = 6f;
    private float waitForJump;

    // private Vector3 auxX;
    // private Vector3 auxZ;

    // Rotação em relação a câmera
    public float rotSpeed = 3f;
    Transform cameraTransform;

    public void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Movement();
    }

    // private void Movement()
    // {
    //     float moveVertical = Input.GetAxis("Vertical");;
    //     if (isGrounded)
    //     {
    //         movementX = auxX;
    //         movementZ = auxZ;
    //     } else {
    //         movementX.x = 0.1f;
    //         movementZ.z = 0.1f;
    //     }
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         rigidBody.velocity += movementZ;
    //     }
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         rigidBody.velocity -= movementZ;
    //     }
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         rigidBody.velocity += movementX;
    //     }
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         rigidBody.velocity -= movementX;
    //     }

    //     if (Input.GetKey(KeyCode.Space) && isGrounded)
    //     {
    //         isGrounded = false;
    //         rigidBody.velocity += jump;
    //         // rigidBody.AddForce(0, jumpSpeed, 0);
    //     }
    // }

    // if (moveVertical != 0)
    // {
    //     Quaternion newRotation;
    //     Vector3 forwardTarget = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
    //     Quaternion changeRotation = Quaternion.FromToRotation(transform.forward, forwardTarget);
    //     newRotation = rigidBody.rotation * changeRotation;
    //     Quaternion finalRotation = Quaternion.Slerp(rigidBody.rotation, newRotation, rotSpeed * Time.deltaTime);
    //     rigidBody.MoveRotation(finalRotation);
    // }
    private void Movement()
    {
        waitForJump = waitForJump - 1 > 0 ? waitForJump - 1 : 0;
        float horizontalInputs = Input.GetAxis("Horizontal");
        float verticalInputs = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInputs * movementSpeed, 0, verticalInputs * movementSpeed);
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        // movementDirection.Normalize();
        rigidBody.AddForce(movementDirection);

        if (Input.GetKey(KeyCode.Space) && isGrounded && waitForJump <= 0)
        {
            waitForJump = 5;
            isGrounded = false;
            rigidBody.AddForce(0, 200f, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    public void SetIsGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
