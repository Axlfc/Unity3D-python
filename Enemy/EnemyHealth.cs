using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth;  // max enemy health
    public int currentHealth;
    public float sinkSpeed;  // enemy sink speed
    public int scoreValue;  // the points that will be given to the player once the enemy has been destroyed
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
    /// Sets the character to a dead state and triggers the death animation.
    /// </summary>
    void Death() {
        isDead = true;
        anim.SetTrigger("Death");

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
