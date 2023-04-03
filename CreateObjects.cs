using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {

    public GameObject cubePrefab;
    public Transform posRotcubePrefab;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        
    }


    /// <summary>
    /// Instantiates the given prefab GameObject at the specified position and rotation in the game scene.
    /// </summary>
    /// <param name="prefab">The prefab GameObject to instantiate.</param>
    /// <param name="position">The position to instantiate the GameObject at.</param>
    /// <param name="rotation">The rotation to instantiate the GameObject with.</param>
    public void SpawnPrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(prefab, position, rotation);
        // Set any properties of the new object here, such as its name, parent, or tag
    }


    /// <summary>
    /// Instantiates the given prefab GameObject after the specified delay.
    /// </summary>
    /// <param name="prefab">The prefab GameObject to instantiate.</param>
    /// <param name="delay">The amount of time to wait before instantiating the GameObject.</param>
    public void SpawnPrefabWithDelay(string objectToInvoke, float delay)
    {
        Invoke(objectToInvoke, delay);
    }


    /// <summary>
    /// Instantiates the given prefab GameObject after the specified delay.
    /// </summary>
    /// <param name="prefab">The prefab GameObject to instantiate.</param>
    /// <param name="delay">The amount of time to wait before instantiating the first GameObject.</param>
    /// <param name="repeatRate">The amount of time to wait between subsequent GameObject instantiations.</param>
    public void SpawnRepeatingPrefabWithDelay(string objectToInvoke, float delay, float repeatRate)
    {
        InvokeRepeating(objectToInvoke, delay, repeatRate);
    }


    /// <summary>
    /// Instantiates a cube prefab with a given position and rotation using the SpawnPrefab method.
    /// </summary>
    void SpawnCube() {
        SpawnPrefab(cubePrefab, posRotcubePrefab.position, posRotcubePrefab.rotation);
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log($"T");
            SpawnPrefabWithDelay("SpawnCube", 2);
            // SpawnRepeatingPrefabWithDelay("SpawnCube", 2, 1);
        }
    }
}
