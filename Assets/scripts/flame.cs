// using UnityEngine;

// public class flame : MonoBehaviour
// {
//     public ParticleSystem flameEffect;       // Assign the particle system
//     public GameObject baseCollider;
//     public float damagePerSecond = 10f;
//     public float flameRange = 5f;
//     public LayerMask enemyLayer;              // Layer for enemies

//     private bool isFiring = false;

//     void Update()
//     {
//         // Start firing when holding left mouse button (or any input you want)
//         if (Input.GetButton("Fire2"))
//         {
//             if (!isFiring)
//             {
//                 flameEffect.Play();
//                 isFiring = true;
//             }
//             //DamageEnemies(); old code but keeping just incase
//         }
//         else
//         {
//             if (isFiring)
//             {
//                 flameEffect.Stop();
//                 isFiring = false;
//             }
//         }
//     }

//     void OnParticleCollision(GameObject other)
//     {
//         if (!isFiring) return;

//         // Check if the object is on the enemy layer
//         if (((1 << other.layer) & enemyLayer) != 0)
//         {
//             enemyhealth enemy = other.GetComponent<enemyhealth>();
//             if (enemy != null)
//             {
//                 enemy.TakeDamage(damagePerSecond * Time.deltaTime);
//             }
//         }
//     }
// }
using UnityEngine;

public class Flame : MonoBehaviour
{
    public ParticleSystem flameEffect;        // Assign the particle system
    public float damagePerSecond = 10f;       // Damage per second
    public float flameRange = 5f;             // Max range of the flame
    public LayerMask enemyLayer;
    public LayerMask wallLayer;             // Layer for enemies
    float flameRadius = 1f;
    private bool isFiring = false;

    void Update()
    {
        // Check for fire input (right mouse button by default = Fire2)
        if (Input.GetButton("Fire1"))
        {
            if (!isFiring)
            {
                flameEffect.Play();
                isFiring = true;
            }

            RaycastFlame();
        }
        else
        {
            if (isFiring)
            {
                flameEffect.Stop();
                isFiring = false;
            }
        }
    }
    void RaycastFlame()
    {
        // Define the origin and direction of the ray
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit wallHit;
        bool wallBlocked = Physics.SphereCast(origin, flameRadius, direction, out wallHit, flameRange, wallLayer);

        float maxDistance = flameRange;

        if (wallBlocked)
        {
            maxDistance = wallHit.distance;  // Stop at the wall
        }

        // Now get all enemies in range, but only up to the wall distance
        RaycastHit[] hits = Physics.SphereCastAll(origin, flameRadius, direction, maxDistance, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
            enemyhealth enemy = hit.collider.GetComponent<enemyhealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
        // Optional: visualize the ray in the editor
        Debug.DrawRay(origin, direction * flameRange, Color.red, 0.1f);
    }
}
