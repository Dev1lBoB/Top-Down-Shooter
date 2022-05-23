using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shot))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private int ammo = 5;
    [SerializeField]
    private float fireRate = 0.1f;

    private float nextShot = 0;

    private Shot shot;

    void Awake()
    {
        shot = GetComponent<Shot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (ammo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + fireRate; // Make sure that the next shot will occur in accordance with the fireRate
            GameObject newProjectile = shot.Fire();
            newProjectile.GetComponent<OnDestroyEvent>().OnDestroyEvnt += Reload; // The amount of projectiles per unit is limited and restores when a projectile is destroyed
            --ammo;
        }
    }

    private void Reload(GameObject projectileGO)
    {
        ++ammo;
    }
}
