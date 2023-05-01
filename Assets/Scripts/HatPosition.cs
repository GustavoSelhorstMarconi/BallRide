using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPosition : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    
    void Start()
    {
        player = transform.parent;
    }

    void FixedUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.identity;
    }
}