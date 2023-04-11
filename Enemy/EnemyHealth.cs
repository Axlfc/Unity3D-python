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

    [Header("Audio")]
    [Tooltip("The sound clip that will play when the enemy dies.")]
    public AudioClip deathClip;

    [Header("Visual Effects")]
    [Tooltip("The particle system that will be played when the enemy is hit.")]
    public ParticleSystem hitParticles;

    Animator anim;
    AudioSource audioSource;
    bool isSinking;  // to know if the enemy "is sinking"


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // hitParticles = GetComponent<ParticleSystem>();
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
    /// Reduces the current health of the enemy by a specified amount and triggers the death sequence if the enemy's health reaches 0 or below.
    /// </summary>
    /// <param name="amount">The amount of damage to be taken.</param>
    /// <param name="point">The position at which the damage was dealt.</param>
    public void TakeDamage(int amount, Vector3 point) {
        if (isDead) return;

        audioSource.Play();

        // Place the particle system at the point of impact of the raycast with the enemy
        hitParticles.transform.position = point;
        hitParticles.Play();

        currentHealth -= amount;

        if (currentHealth <= 0) Death();
    }


    /// <summary>
    /// Called when the player dies. Sets the isDead flag to true, triggers the Death animation and sends the score value to the GameManager's ScoreEnemy function.
    /// </summary>
    void Death() {
        audioSource.clip = deathClip;
        audioSource.Play();

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
