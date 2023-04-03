using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    public GameObject cube;

    /// <summary>
    /// Called when the user presses a mouse button while the mouse is over the object.
    /// </summary>
    private void OnMouseDown()
    {
        // Debug.Log("Click sobre el objeto");
        // DestroyGameObject(cube);
    }

    /// <summary>
    /// Called when the user releases a mouse button that was previously pressed while the mouse was over the object.
    /// </summary>
    private void OnMouseUp()
    {
        // Debug.Log("Click soltado sobre el objeto");
    }

    /// <summary>
    /// Called every frame while the user is holding down a mouse button and moving the mouse over the object.
    /// </summary>
    private void OnMouseDrag()
    {
        // Debug.Log("Click y arrastrar el objeto");
    }

    /// <summary>
    /// Called every frame while the mouse is over the object.
    /// </summary>
    private void OnMouseOver()
    {
        // Debug.Log("Mouse sobre el objeto");
    }

    /// <summary>
    /// Called when the mouse pointer enters the object's collider.
    /// </summary>
    private void OnMouseEnter()
    {
        // Debug.Log("Mouse entra sobre el objeto");
    }

    /// <summary>
    /// Called when the mouse pointer exits the object's collider.
    /// </summary>
    private void OnMouseExit()
    {
        // Debug.Log("Mouse sale sobre el objeto");
    }


    /// <summary>
    /// Destroys the given GameObject after the specified delay.
    /// </summary>
    /// <param name="gameObject">The GameObject to destroy.</param>
    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Destroys the given GameObject after the specified delay.
    /// </summary>
    /// <param name="gameObject">The GameObject to destroy.</param>
    /// <param name="delay">The amount of time to wait before destroying the GameObject.</param>
    public void DestroyGameObjectWithDelay(GameObject gameObject, float delay)
    {
        Destroy(gameObject, delay);
    }

    /// <summary>
    /// Destroys the component of the given type attached to the given GameObject after the specified delay.
    /// </summary>
    /// <param name="gameObject">The GameObject that has the component to destroy.</param>
    /// <param name="componentType">The type of component to destroy.</param>
    /// <param name="delay">The amount of time to wait before destroying the component.</param>
    public void DestroyComponent(GameObject gameObject, Type componentType, float delay)
    {
        Component component = gameObject.GetComponent(componentType);
        if (component != null && component is Behaviour)
        {
            Destroy(component as Behaviour, delay);
        }
    }



}
