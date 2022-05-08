using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoatCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public float damping = 1f;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    public void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime + damping);
        transform.LookAt(target.transform);
    }
}
