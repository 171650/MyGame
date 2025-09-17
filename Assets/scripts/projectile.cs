using System.ComponentModel;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Camera cam;
    public GameObject Projectile;
    public Transform FirePoint;
    public float projectilespeed = 30;
    public float fireRate = 4;
    private float TimeToFire;
    private Vector3 destination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= TimeToFire)
        {
            TimeToFire = Time.time + 1 / fireRate;
            Shootprojectile();
        }
    }

    void Shootprojectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        
        InstantiateProjectile(FirePoint);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(Projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = (destination - firePoint.position).normalized * projectilespeed;
    }
    
    
    
}
