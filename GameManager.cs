using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Array Positions")]
    public Transform[] positions;  // Positions array (empty objects placed in the scene)

    [Header("Array Enemies")]
    public GameObject[] enemyPrefabs;

    [Space]
    public Transform parentEnemies;  // the empty gameobject that will be the parent of the enemy clones

    [Tooltip("How often will instantiate enemies")]
    [Range(2, 6)]
    public float time;  // How often will instantiate enemies

    
    void CreateEnemy() {
        int pos = Random.Range(0, positions.Length);
        int enemy = Random.Range(0, enemyPrefabs.Length);
        GameObject cloneEnemy = Instantiate(enemyPrefabs[enemy], positions[pos].position, positions[pos].rotation);
        cloneEnemy.transform.SetParent(parentEnemies);
    }
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InvokeRepeating("CreateEnemy", time, time);
    }




    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        
    }
}
