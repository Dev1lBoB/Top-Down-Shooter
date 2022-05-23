using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterCombo : MonoBehaviour
{
    private ComboUI comboUI;

    void Awake()
    {
        comboUI = GameObject.Find("Menu").GetComponent<ComboUI>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 3) // Projectile layer
        {
            if (coll.gameObject.GetComponent<ProjectileBounce>().isActive == false) // Ignore fake hit when the projectile is just instantiated
                return ;
            
            string finalCombo; // Here we will write information about the combo

            int ricochetCounter = coll.gameObject.GetComponent<ActionsCombo>().ricochetCounter;

            if (ricochetCounter == 0)
            {
                finalCombo = gameObject.name + " dies after direct hit!";
            }
            else
            {
                finalCombo = gameObject.name + " dies after being shot with " + ricochetCounter + " ricochet";
                finalCombo += ricochetCounter == 1 ? "!" : "s!";
            }

            comboUI.ShowCombo(finalCombo);
        }

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.layer == 7) // Death wall layer
        {
            comboUI.ShowCombo(gameObject.name + " fell out of the map!");
        }
    }
}
