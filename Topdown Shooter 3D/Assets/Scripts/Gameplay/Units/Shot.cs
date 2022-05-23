using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;
    [SerializeField]
    private Transform   firePoint;
    [SerializeField]
    private float       firePower;

    public GameObject Fire()
    {
        // Fires forward projectile out of the settled point
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        Rigidbody newProjectileRb = newProjectile.GetComponent<Rigidbody>();

        newProjectileRb.AddForce(transform.forward * firePower, ForceMode.Impulse);

        return newProjectile;
    }
}
