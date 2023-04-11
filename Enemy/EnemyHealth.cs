using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [Header("Health")]
    [Tooltip("The maximum health of the enemy")]
    public int maxHealth;

    [Tooltip("The current health of the enemy")]
    public int currentHealth;

    [Header("Sinking")]
    [Tooltip("The speed at which the enemy sinks into the ground when it dies")]
    public float sinkSpeed;

    [Header("Score")]
    [Tooltip("The number of points awarded to the player when this enemy is destroyed")]
    public int scoreValue;

    [Header("Status")]
    [Tooltip("Indicates whether the enemy is currently dead")]
    public bool isDead;

    Animator anim;
    bool isSinking;  // to know if the enemy "is sinking"


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
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
        if (isSinking == true) transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
    }


    /// <summary>
    /// Reduces the current health of the object by the specified amount and checks if it has died.
    /// </summary>
    /// <param name="amount">The amount of damage to take.</param>
    public void TakeDamage(int amount) {
        if (isDead) return;

        currentHealth -= amount;

        if (currentHealth <= 0) Death();
    }


    /// <summary>
    /// Called when the player dies. Sets the isDead flag to true, triggers the Death animation and sends the score value to the GameManager's ScoreEnemy function.
    /// </summary>
    void Death() {
        isDead = true;
        anim.SetTrigger("Death");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ScoreEnemy(scoreValue);

    }


    /// <summary>
    /// Starts sinking the game object after the death animation is played.
    /// Disables the NavMeshAgent component and destroys the game object after a set time.
    /// </summary>
    public void StartSinking() {
        isSinking = true;
        // Disabling the component NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2);
    }
}
