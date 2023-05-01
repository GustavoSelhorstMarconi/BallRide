using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    public Transform GetWayPoint(int wayPointIndex)
    {
        return transform.GetChild(wayPointIndex);
    }

    public int GetNextWayPointIndex(int currentWayPoint)
    {
        int nextWayPointIndex = currentWayPoint + 1;

        if (nextWayPointIndex == transform.childCount)
        {
            nextWayPointIndex = 0;
        }

        return nextWayPointIndex;
    }
}
