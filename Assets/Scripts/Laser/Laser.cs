using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPosition;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, startPosition.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if (hit.collider)
            {
                Vector3 positionEnd = new Vector3(hit.point.x - hit.collider.bounds.size.x, startPosition.position.y, startPosition.position.z);
                lineRenderer.SetPosition(1, positionEnd);
            }
        }
        else {
            lineRenderer.SetPosition(1, -transform.right * 1000);
        }
    }
}