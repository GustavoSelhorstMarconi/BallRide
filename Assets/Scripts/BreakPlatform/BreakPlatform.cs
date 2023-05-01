using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public struct InfoPieces
// {
//     public Vector3 positionStart;
//     public Quaternion rotationStart;

//     public Transform transformPiece;
//     public Rigidbody rigidBodyPiece;

//     public InfoPieces(Vector3 positionStart, Quaternion rotationStart, Transform transformPiece, Rigidbody rigidBodyPiece)
//     {
//         this.positionStart = positionStart;
//         this.rotationStart = rotationStart;
//         this.transformPiece = transformPiece;
//         this.rigidBodyPiece = rigidBodyPiece;
//     }
// }

public class BreakPlatform : MonoBehaviour
{
    public float timeToWait;
    public float forceMin;
    public float forceMax;

    private List<Rigidbody> pieces = new List<Rigidbody>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Rigidbody rigidBodyPiece = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
            pieces.Add(rigidBodyPiece);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlatformBreak());
        }
    }

    private IEnumerator PlatformBreak()
    {
        yield return new WaitForSeconds(timeToWait);

        foreach (Rigidbody piece in pieces)
        {
            piece.isKinematic = false;

            float xForce = Random.Range(forceMin, forceMax);
            float yForce = Random.Range(forceMin, forceMax);
            float zForce = Random.Range(forceMin, forceMax);

            piece.AddForce(xForce, yForce, zForce, ForceMode.Force);
        }
    }
}
