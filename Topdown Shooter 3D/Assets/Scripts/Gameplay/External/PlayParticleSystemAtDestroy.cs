using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystemAtDestroy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    private void OnDestroy()
    {
        // Unparent particle system from an object, so it won't be deleted with him
        particles.transform.parent = null;
        particles.Play();
    }
}
