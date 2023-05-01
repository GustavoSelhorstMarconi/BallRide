using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActReplay : MonoBehaviour
{
    private bool inReplayMode;
    private int actualReplayIndex;
    private List<ReplayRecord> replayRecords = new List<ReplayRecord>();
    private Rigidbody rigidBody;
    private Collider collider;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.R))
    //     {
    //         inReplayMode = !inReplayMode;

    //         if (inReplayMode)
    //         {
    //             SetTransform(0);
    //             rigidBody.isKinematic = true;
    //         }
    //         else
    //         {
    //             SetTransform(replayRecords.Count - 1);
    //             rigidBody.isKinematic = false;
    //         }
    //     }
    // }

    void FixedUpdate()
    {
        if (inReplayMode == false)
        {
            replayRecords.Add(new ReplayRecord { pos = transform.position, rot = transform.rotation });
        }
        else
        {
            int nextIndex = actualReplayIndex + 1;

            if (nextIndex < replayRecords.Count)
            {
                SetTransform(nextIndex);
            }
            else
            {
                actualReplayIndex = 0;
            }
        }
    }

    private void SetTransform(int index)
    {
        actualReplayIndex = index;
        ReplayRecord replayRecord = replayRecords[index];

        transform.position = replayRecord.pos;
        transform.rotation = replayRecord.rot;
    }

    public void ChangeReplayMode()
    {
        inReplayMode = !inReplayMode;

        if (inReplayMode)
        {
            SetTransform(0);
            rigidBody.isKinematic = true;
            collider.enabled = false;
        }
        else
        {
            SetTransform(replayRecords.Count - 1);
            rigidBody.isKinematic = false;
            collider.enabled = true;
        }
    }
}
