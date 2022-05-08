using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public int floaterCount = 1;

    void FixedUpdate()
    {
        Rigidbody rigidBody = gameObject.GetComponentInParent<Rigidbody>();
        rigidBody.AddForceAtPosition(floaterCount * Physics.gravity, transform.position, ForceMode.Acceleration);
    }
}
