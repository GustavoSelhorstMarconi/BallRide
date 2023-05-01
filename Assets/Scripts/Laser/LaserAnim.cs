using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnim : MonoBehaviour
{
    private List<Transform> lasers;
    private GameObject laserCollider;
    public float timeToAnim;
    
    void Start()
    {
        lasers = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name == "Laser")
            {
                lasers.Add(child);
            }
        }
        laserCollider = transform.Find("LaserCollider").gameObject;

        InvokeRepeating("DisableLasers", timeToAnim, 2 * timeToAnim);
        InvokeRepeating("EnableLasers", 2 * timeToAnim, 2 * timeToAnim);
    }
    
    void EnableLasers()
    {
        foreach (Transform laser in lasers)
        {
            laser.gameObject.SetActive(true);
        }
        laserCollider.SetActive(true);
    }

    void DisableLasers()
    {
        foreach (Transform laser in lasers)
        {
            laser.gameObject.SetActive(false);
        }
        laserCollider.SetActive(false);
    }
}
