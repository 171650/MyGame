using Unity.Mathematics;
using UnityEngine;

public class Projectilesettings : MonoBehaviour
{
    public GameObject impactvfx;
    public float radius;
    public float force;
    private bool collided;
    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            var impact = Instantiate(impactvfx, transform.position, quaternion.identity) as GameObject;
            Destroy(impact, 3);
            knockback();
            Destroy(gameObject);
        }
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider grav in colliders)
        {
            Rigidbody pull = grav.GetComponent<Rigidbody>();
            if (pull != null)
            {
                pull.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
