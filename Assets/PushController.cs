using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    public float strength = 500;
    public float boatLength = 1f;
    public float boatWidth = 1f;
    public float boatHeight = 1f;
    public int sailCount = 1;

    public 

    Vector3 GetInputTranslationDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        return direction;
    }

    void FixedUpdate()
    {
        Vector3 direction = GetInputTranslationDirection();
        float sin = Mathf.Abs(Mathf.Sin(gameObject.transform.eulerAngles.y * 3.14f / 180f));
        float cos = Mathf.Abs(Mathf.Cos(gameObject.transform.eulerAngles.y * 3.14f / 180f));
        Debug.Log(sin.ToString() + cos.ToString());
        float crossSectionX = boatHeight * (cos * boatWidth + sin * boatLength);
        float crossSectionZ = boatHeight * (cos * boatLength + sin * boatWidth);
        float forceX = direction.x * crossSectionX * Time.fixedDeltaTime * strength;
        float forceZ = direction.z * crossSectionZ * Time.fixedDeltaTime * strength;
        Vector3 windForce = new Vector3(forceX, 0, forceZ) / sailCount;
        Rigidbody rigidBody = gameObject.GetComponentInParent<Rigidbody>();
        rigidBody.AddForceAtPosition(windForce, transform.position, ForceMode.Acceleration);
    }
}
