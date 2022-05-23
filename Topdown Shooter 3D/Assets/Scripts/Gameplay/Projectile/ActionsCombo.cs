using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsCombo : MonoBehaviour
{
    [HideInInspector]
    public int ricochetCounter = 0;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 6) // Wall layer
        {
            ++ricochetCounter;
        }
    }
}
