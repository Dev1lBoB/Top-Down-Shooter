using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEvent : MonoBehaviour
{
    public event OnDestroyDelegate OnDestroyEvnt;
 
    public delegate void OnDestroyDelegate(GameObject go);

    private void OnDestroy()
    {
        // Send notification that this object is about to be destroyed
        if (this.OnDestroyEvnt != null)
            this.OnDestroyEvnt(this.gameObject);
    }
}
