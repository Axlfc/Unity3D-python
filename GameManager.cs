using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [Header("Game Over")]
    public GameObject panelGameOver;

    [Header("Score")]
    [Tooltip("The text component that displays the current score")]
    public TextMeshProGUI textScore;

    [Header("Array Positions")]
    [Tooltip("The array of empty objects placed in the scene where enemies will spawn")]
    public Transform[] positions;

    [Header("Array Enemies")]
    [Tooltip("The array of enemy prefabs that can be spawned")]
    public GameObject[] enemyPrefabs;

    [Space]

    [Header("Parent Enemies")]
    [Tooltip("The empty gameobject that will be the parent of the enemy clones")]
    public Transform parentEnemies;

    [Header("Enemy Spawn Time")]
    [Tooltip("How often enemies will be instantiated")]
    [Range(2, 6)]
    public float time;

    [Header("Score")]
    [Tooltip("The total score of the game")]
    public int score;


    /// <summary>
    /// Instantiates a random enemy prefab at a random position from a list of positions, and sets it as a child of a parent object.
    /// </summary>
    void CreateEnemy() {
        int pos = Random.Range(0, positions.Length);
        int enemy = Random.Range(0, enemyPrefabs.Length);
        GameObject cloneEnemy = Instantiate(enemyPrefabs[enemy], positions[pos].position, positions[pos].rotation);
        cloneEnemy.transform.SetParent(parentEnemies);
    }


    /// <summary>
    /// Displays the game over panel when called.
    /// </summary>
    public void GameOver() {
        panelGameOver.SetActive(true);
    }


    /// <summary>
    /// Load a scene by name using Unity's SceneManager class
    /// </summary>
    /// <param name="name">The name of the scene to load</param>
    public void LoadScene(string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }


    /// <summary>
    /// Adds the given scoreValue to the current score, and updates the text score display accordingly.
    /// </summary>
    /// <param name="scoreValue">The amount of score to add.</param>
    public voide ScoreEnemy(int scoreValue) {
        score += scoreValue;
        textScore.text = "Score: " + score.ToString();
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
