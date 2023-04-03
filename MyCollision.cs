using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour {
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }


    /// <summary>
    /// Called when a collision occurs between two colliders.
    /// </summary>
    /// <param name="collision">The Collision data associated with this collision event.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) {
            Debug.Log("Collision entered with the floor");
        } else {
            Debug.Log("Collision entered with: " + collision.gameObject.name);
        }
    }

    /// <summary>
    /// Called when a 2D collision occurs between two colliders.
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision event.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("2D collision entered with: " + collision.gameObject.name);
    }

    /// <summary>
    /// Called when a collision between two colliders stops.
    /// </summary>
    /// <param name="collision">The Collision data associated with this collision event.</param>
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exited with: " + collision.gameObject.name);
    }

    /// <summary>
    /// Called when a 2D collision between two colliders stops.
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision event.</param>
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("2D collision exited with: " + collision.gameObject.name);
    }

    /// <summary>
    /// Called every frame while a collision between two colliders is occurring.
    /// </summary>
    /// <param name="collision">The Collision data associated with this collision event.</param>
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Collision staying with the floor");
        }
        else
        {
            Debug.Log("Collision staying with: " + collision.gameObject.name);
        }
    }

    /// <summary>
    /// Called every frame while a 2D collision between two colliders is occurring.
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision event.</param>
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("2D collision staying with: " + collision.gameObject.name);
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }
}
