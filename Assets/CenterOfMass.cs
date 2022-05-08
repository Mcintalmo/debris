using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponentInParent<Rigidbody>();
        rigidBody.centerOfMass = transform.position;
    }

}
