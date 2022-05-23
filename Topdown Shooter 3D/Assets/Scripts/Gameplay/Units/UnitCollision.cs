using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 3) // Projectile layer
        {
            // Destroys unit if the projectile is not "newborn"
            if (coll.gameObject.GetComponent<ProjectileBounce>().isActive == true)
                Destroy(gameObject);
        }
    }
}
