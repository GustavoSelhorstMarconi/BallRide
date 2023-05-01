using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseBarrer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            transform.parent.gameObject.GetComponent<Animator>().Play("DecreaseBarrer");
        }
    }
}