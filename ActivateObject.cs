using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {
    // Variables Declaration
    public GameObject cubeLight;
    public GameObject cube;
    private GameObject[] myGameObjects;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        GameObject[] myGameObjects = new GameObject[] { cube };
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    /// <summary>
    /// Toggles the active state of a given GameObject.
    /// </summary>
    /// <param name="gameObjectToToggle">The GameObject to toggle.</param>
    void ToggleGameObject(GameObject gameObjectToToggle) {
        gameObjectToToggle.SetActive(!gameObjectToToggle.activeSelf);
    }

    /// <summary>
    /// Toggles the active state of an array of game objects.
    /// </summary>
    /// <param name="gameObjects">The array of game objects to toggle.</param>
    /// <param name="setActive">The state to set the game objects to.</param>
    void ToggleGameObjects(GameObject[] gameObjects, bool setActive) {
        foreach (GameObject gameObject in gameObjects) {
            gameObject.SetActive(setActive);
        }
    }


    /// <summary>
    /// Activates the specified game object if it is not already active.
    /// </summary>
    /// <param name="gameObjectToActivate">The game object to activate.</param>
    void ActivateGameObject(GameObject gameObjectToActivate) {
        if (!gameObjectToActivate.activeSelf) {
            // Activate the specified object
            gameObjectToActivate.SetActive(true);
        }
    }

    ///<summary>
    ///Activates an array of game objects, deactivating all other objects
    ///</summary>
    ///<param name="gameObjectsToActivate">The array of game objects to activate</param>
    void ActivateGameObjects(GameObject[] gameObjectsToActivate) {
        // Activate each object in the array
        foreach (GameObject gameObject in gameObjectsToActivate) {
            ActivateGameObjectExclusive(gameObject);
        }
    }

    /// <summary>
    /// Activates the specified game object exclusively, deactivating any other active game objects.
    /// </summary>
    /// <param name="gameObjectToActivate">The game object to activate exclusively.</param>
    void ActivateGameObjectExclusive(GameObject gameObjectToActivate) {
        if (!gameObjectToActivate.activeSelf) {
            // Deactivate any other objects that might be active
            DeactivateAllGameObjects(gameObjectToActivate);

            // Activate the specified object
            gameObjectToActivate.SetActive(true);
        }
    }

    /// <summary>
    /// Activates an array of GameObjects exclusively, deactivating all other objects that might be active.
    /// </summary>
    /// <param name="gameObjectsToActivate">Array of GameObjects to activate exclusively.</param>
    /// <remarks>
    /// This function first deactivates all other objects that might be active and then activates each object in the specified array.
    /// </remarks>
    void ActivateGameObjectsExclusive(GameObject[] gameObjectsToActivate) {
        // Deactivate all other objects first
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>()) {
            if (gameObject.activeSelf && !gameObjectsToActivate.Contains(gameObject)) {
                gameObject.SetActive(false);
            }
        }

        // Activate each object in the array
        foreach (GameObject gameObject in gameObjectsToActivate) {
            ActivateGameObjectExclusive(gameObject);
        }
    }

    ///<summary>
    ///Activates the first inactive GameObject found in the scene.
    ///</summary>
    void ActivateAnyGameObject() {
        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
            if (!go.activeSelf) {
                go.SetActive(true);
                break;
            }
        }
    }

    ///<summary> Activates all GameObjects in the scene that are not already active.
    ///</summary>
    ///<remarks> This function searches for all active GameObjects in the scene and activates any that are currently inactive.</remarks>
    void ActivateAllGameObjects() {
        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
            if (!go.activeSelf) {
                go.SetActive(true);
            }
        }
    }


    ///<summary>
    /// Deactivates the specified GameObject if it is currently active.
    ///</summary>
    ///<param name="gameObjectToDeactivate">The GameObject to deactivate.</param>
    void DeactivateGameObject(GameObject gameObjectToDeactivate) {
        if (gameObjectToDeactivate.activeSelf) {
            // Deactivate the specified object
            gameObjectToDeactivate.SetActive(false);
        }
    }

    /// <summary>
    /// Deactivates an array of GameObjects
    /// </summary>
    /// <param name="gameObjectsToDeactivate">The GameObjects to deactivate</param>
    void DeactivateGameObjects(GameObject[] gameObjectsToDeactivate) {
        // Deactivate each object in the array
        foreach (GameObject gameObject in gameObjectsToDeactivate) {
            DeactivateGameObjectExclusive(gameObject);
        }
    }

    /// <summary>
    /// Deactivates the specified game object exclusively, deactivating any other active game object.
    /// </summary>
    /// <param name="gameObjectToDeactivate">The game object to deactivate exclusively.</param>
    void DeactivateGameObjectExclusive(GameObject gameObjectToDeactivate) {
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>()) {
            if (gameObject.activeSelf && gameObject != gameObjectToDeactivate) {
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Deactivates an array of GameObjects exclusively, meaning that only the specified objects will be deactivated, and any other active objects will be activated.
    /// </summary>
    /// <param name="gameObjectsToDeactivate">An array of GameObjects to deactivate exclusively.</param>
    void DeactivateGameObjectsExclusive(GameObject[] gameObjectsToDeactivate) {
        // Activate all other objects first
        foreach (GameObject gameObject in gameObjectsToDeactivate) {
            ActivateGameObjectExclusive(gameObject);
        }

        // Deactivate each object in the array
        foreach (GameObject gameObject in gameObjectsToDeactivate) {
            DeactivateGameObjectExclusive(gameObject);
        }
    }

    /// <summary>
    /// Deactivates all active GameObjects except the specified one.
    /// </summary>
    /// <param name="gameObjectToActivate">The GameObject to exclude from deactivation.</param>
    void DeactivateAllGameObjects(GameObject gameObjectToActivate) {
        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
            if (go.activeSelf) {
                if (go != gameObjectToActivate) {
                    go.SetActive(false);
                }
            }
        }
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log($"SPACE");
            //ActivateGameObjectExclusive(cubeLight);
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log($"RETURN");
            //DeactivateGameObjectExclusive(cubeLight);
        }
    }
}
