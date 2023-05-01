using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
  public Vector3 direction;
  public float speed;

  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.gameObject.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
    }
  }
}