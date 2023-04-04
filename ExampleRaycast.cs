using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRaycast : MonoBehaviour {
    public GameObject _object;
    public float rayLength;
    public LayerMask layerRay;

    Ray ray;
    RaycastHit hit;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        
    }

    /// <summary>
    /// Sets the origin and direction of a ray from the current transform position and forward direction.
    /// If the ray intersects with any objects on the specified layer, stores the collided GameObject in a private field and logs the name of the hit collider to the console.
    /// If the ray doesn't intersect with anything, logs a message to the console.
    /// Draws a debug ray in the scene view for visualization purposes.
    /// </summary>
    void Update() {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out hit, rayLength, layerRay)) {
            _object = hit.collider.gameObject;
            Debug.Log($"Hitting something:\t{hit.collider.name}");
        } else Debug.Log("Not hitting anything.");

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    }
}
