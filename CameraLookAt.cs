using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform targetTransform;
    // public GameObject targetGameObject;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
    }


    /// <summary>
    /// Rotates the object's transform so it looks at the specified target.
    /// </summary>
    /// <param name="targetToLookAt">The target to look at, which can be a Transform or a GameObject.</param>
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

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        LookAtTarget(targetTransform);
        // LookAtTarget(targetGameObject);
    }
}
