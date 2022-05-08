using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public float cooldown = 1f;
    public float damageFactor = 1.0f;

    private float canCollide = -1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time > canCollide)
        {
            Debug.Log($"{gameObject.name} is colliding with {collision.collider.name} at speed {collision.relativeVelocity.magnitude}");
            canCollide = Time.time + cooldown;
            
            var em = particleEffect.emission;
            em.rateOverTime = 100 * collision.relativeVelocity.magnitude;
            particleEffect.startSpeed = collision.relativeVelocity.magnitude;
            particleEffect.transform.position = collision.transform.position;
            particleEffect.Play();

            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.Damage(collision.relativeVelocity.magnitude * damageFactor);
            }
        }
    }
}
