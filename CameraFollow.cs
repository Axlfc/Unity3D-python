using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    public float smoothing;  // tracking speed from camera to player

    Vector3 offset;  // initial distance between camera and player


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        offset = transform.position - player.position;
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        
    }


    void LateUpdate() {
        // we calculate the position to which we want to move the camera
        Vector3 targetCamPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

}
