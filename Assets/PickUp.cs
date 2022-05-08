using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float resources = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            Debug.Log($"{gameObject.name} is colliding with {other.name}");
            player.Gather(resources);
            Destroy(gameObject);
        }
    }
}