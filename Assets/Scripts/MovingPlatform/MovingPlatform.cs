using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WayPointPath wayPointPath;

    [SerializeField]
    private float speed;
    
    private int targetWayPointIndex;

    private Transform previousWayPoint;
    private Transform targetWayPoint;

    private float timeToWayPoint;
    private float passedTime;

    void Start()
    {
        TargetNextWayPoint();
    }

    void FixedUpdate()
    {
        passedTime += Time.deltaTime;

        float passedPercentage = passedTime / timeToWayPoint;
        passedPercentage = Mathf.SmoothStep(0, 1, passedPercentage);
        transform.position = Vector3.Lerp(previousWayPoint.position, targetWayPoint.position, passedPercentage);
        transform.rotation = Quaternion.Lerp(previousWayPoint.rotation, targetWayPoint.rotation, passedPercentage);

        if (passedPercentage >= 1)
        {
            TargetNextWayPoint();
        }
    }

    private void TargetNextWayPoint()
    {
        previousWayPoint = wayPointPath.GetWayPoint(targetWayPointIndex);
        targetWayPointIndex = wayPointPath.GetNextWayPointIndex(targetWayPointIndex);
        targetWayPoint = wayPointPath.GetWayPoint(targetWayPointIndex);

        passedTime = 0;

        float distanceToWayPoint = Vector3.Distance(previousWayPoint.position, targetWayPoint.position);
        timeToWayPoint = distanceToWayPoint / speed;
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
