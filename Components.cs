using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Components : MonoBehaviour {
    // https://docs.unity3d.com/Manual/ScriptingImportantClasses.html
    Light lightCube;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        lightCube = GetComponent<Light>();
    }


    /// <summary>
    /// Toggles the enabled state of a component of the target gameobject.
    /// </summary>
    /// <param name="gameObject">The gameobject that contains the component to toggle.</param>
    /// <param name="componentType">The type of the component to toggle.</param>
    void ToggleComponent(GameObject gameObject, Type componentType) {
        Component component = gameObject.GetComponent(componentType);
        if (component != null && component is Behaviour) {
            (component as Behaviour).enabled = !(component as Behaviour).enabled;
        }
    }


    /// <summary>
    /// Toggles the enabled state of the Light component of the cubeLight gameobject.
    /// </summary>
    /// <param name="gameObject">The gameobject that contains the Light component to toggle.</param>
    void ToggleLightComponent(GameObject gameObject) {
        ToggleComponent(gameObject, typeof(Light));
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            ToggleLightComponent(lightCube.gameObject);
        }
    }
}
