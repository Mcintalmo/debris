using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 10.0f;
    public float resources = 0.0f;

    private void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
    }

    public void Damage(float value)
    {
        health -= value;
    }

    public void Gather(float value)
    {
        resources += value;
    }
}
