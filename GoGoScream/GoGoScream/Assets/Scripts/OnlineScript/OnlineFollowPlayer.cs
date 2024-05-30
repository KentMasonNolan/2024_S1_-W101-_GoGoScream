using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineFollowPlayer : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 4, -8);
    private Transform playerTransform;

    public void SetTarget(Transform target)
    {
        playerTransform = target;
    }

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position with offset
            Vector3 desiredPosition = playerTransform.position + offset;
            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


