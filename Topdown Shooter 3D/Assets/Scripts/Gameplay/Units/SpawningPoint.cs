using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPoint : MonoBehaviour
{
    [HideInInspector]
    public Vector3 spawnPoint;
    [HideInInspector]
    public Vector3 spawnRotation;

    void Start()
    {
        spawnPoint = transform.position;
        spawnRotation = transform.eulerAngles;
    }
}
