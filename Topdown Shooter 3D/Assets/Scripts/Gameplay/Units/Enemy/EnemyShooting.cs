using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shot))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private int ammo = 5;
    [SerializeField]
    private float fireRate = 0.1f;
    [SerializeField]
    private float maxFireRange = 500f;

    [SerializeField]
    private int maxRikochetsToCalculate = 3; // Amount of times ray can bounce out of the wall to aim at the player

    private float nextShot = 0;
    public Transform target;

    private Shot shot;

    void Awake()
    {
        shot = GetComponent<Shot>();
    }

    void Update()
    {
        Aim(transform.position, transform.forward, maxRikochetsToCalculate);
    }

    private void Aim(Vector3 start, Vector3 direction, int rikochetsLeft)
    {
        if (rikochetsLeft == -1) // Stop aiming if there were already used all ricochets
            return ;

        RaycastHit hit;

        if (Physics.Raycast(start, direction, out hit, maxFireRange))
        {
            if (hit.transform.tag == "Player")
            {
                // Shoot, if we found a player in a way
                Fire();
            }
            else if (hit.transform.tag == "Wall")
            {
                // Use recursion to continue searching for the player with ricochet from the wall
                Aim(hit.point, Vector3.Reflect(direction, hit.normal), rikochetsLeft - 1);
            }
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
