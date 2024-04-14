using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform carTransform;
    private Transform thisTransform;

    void Start()
    {
        thisTransform = this.transform;
    }

    void Update()
    {
        Vector3 pos = new Vector3(carTransform.position.x, 34, carTransform.position.z);   
        thisTransform.position = pos;   
    }
}
