using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool followTarget = false;
    public Transform target;
    public float smoothingPower = 0.2f;

    private void FixedUpdate()
    {
        if (followTarget)
        {
            FollowTargetWithoutHorizontal();
        }
    }

    private void FollowTargetWithoutHorizontal()
    {
        Vector3 dest = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, dest, smoothingPower);
    }
}
