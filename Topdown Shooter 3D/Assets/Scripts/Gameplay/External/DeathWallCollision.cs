using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider coll)
    {
        // Destroys every object that goes out of this collider
        Destroy(coll.gameObject);
    }
}
