using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaenManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints = new Transform[25];

    public Vector3 GetRandomPosition()
    {
        return spawnPoints[UnityEngine.Random.Range(0,24)].position;
    }

}
