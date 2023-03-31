using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform targetTransform;
    // public GameObject targetGameObject;

    // Start is called before the first frame update
    void Start() {
    }


    void LookAtTarget(object targetToLookAt)
    {
        Transform transformToRotate = transform;

        if (targetToLookAt is Transform)
        {
            transformToRotate.LookAt((Transform)targetToLookAt);
        }
        else if (targetToLookAt is GameObject)
        {
            transformToRotate.LookAt(((GameObject)targetToLookAt).transform);
        }
    }

    // Update is called once per frame
    void Update() {
        LookAtTarget(targetTransform);
        // LookAtTarget(targetGameObject);
    }
}
