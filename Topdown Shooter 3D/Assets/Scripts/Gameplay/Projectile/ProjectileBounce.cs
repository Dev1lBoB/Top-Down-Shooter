using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBounce : MonoBehaviour
{
    private Rigidbody   rb;
    private Vector3     lastVelocity;

    [HideInInspector]
    public bool isActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Save the current velocity, to not loose it at the moment of collision
        lastVelocity = rb.velocity;
    }

    private void Bounce(Collision coll)
    {
        // Bounce out of the wall without losing any velocity
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        
        rb.velocity = direction * Mathf.Max(speed, 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 6) // Wall layer
        {
            isActive = true;
            Bounce(coll);
        }
        else
        {
            // Prevent situation when player/enemy self destroys from the "newborn" projectile
            if (isActive)
                Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.layer != 6) // Wall layer
        {
            // Set projectile status to active as soon as it leaves unit collider
            isActive = true;
        }
    }
}
