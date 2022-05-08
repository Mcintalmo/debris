using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float strength = 1f;
    public Transform cameraTransform;
    public Transform waterTransform;
    public bool local = false;
    public float cameraDistanceFactor = 0.1f;

    Vector3 GetInputTranslationDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += local ? gameObject.transform.forward : Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += local ? -gameObject.transform.forward : Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += local ? -gameObject.transform.right : Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += local ? gameObject.transform.right : Vector3.right;
        }
        return direction;
    }

    private void Update()
    {
        float xz_speed = cameraDistanceFactor * Mathf.Sqrt(rigidBody.velocity.x * rigidBody.velocity.x + rigidBody.velocity.z * rigidBody.velocity.z);
        cameraTransform.position = rigidBody.position + (2 + xz_speed) * Vector3.back + (2 + xz_speed) * Vector3.up;
        waterTransform.position = new Vector3(rigidBody.position.x, waterTransform.position.y, rigidBody.position.z);
    }

    void FixedUpdate()
    {
        var translation = GetInputTranslationDirection() * Time.fixedDeltaTime;
        rigidBody.AddForce(strength * translation, ForceMode.Force);
    }
}
