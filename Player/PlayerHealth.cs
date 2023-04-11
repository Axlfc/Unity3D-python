using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [Header("Health")]
    [Tooltip("The maximum health of the player.")]
    public float maxHealth;
    [Tooltip("The current health of the player.")]
    public float currentHealth;

    [Header("UI")]
    [Tooltip("The slider that displays the player's health.")]
    public Slider slider;
    [Tooltip("The image that appears when the player takes damage.")]
    public Image damageImage;
    [Tooltip("The image that displays the player's health.")]
    public Image healthImage;

    [Header("Damage Flash")]
    [Tooltip("The speed at which the damage image will disappear.")]
    public float flashSpeed;
    [Tooltip("The color of the damage image when the player takes damage.")]
    public Color flashColor;

    [Header("Game Manager")]
    [Tooltip("The GameManager that controls the game.")]
    public GameManager gameManager;

    [Header("Audio")]
    [Tooltip("The sound clip that will play when the player dies.")]
    public AudioClip deathClip;

    Animator anim;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    AudioSource audioSource;
    bool isDead;
    bool damaged;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        healthImage.fillAmount = 1f;

        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        audioSource = GetComponent<AudioSource>();
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    /// <summary>
    /// This function is called when the player takes damage.
    /// </summary>
    /// <param name="amount">The amount of damage taken.</param>
    public void TakeDamage(int amount) {
        if (isDead) return;  // if the player dies the function is exited

        audioSource.Play();

        damaged = true;
        currentHealth -= amount;
        slider.value = currentHealth;
        healthImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0) Death();
    }


    /// <summary>
    /// This function handles the death of the player. It sets the isDead flag to true, triggers the death animation and disables the PlayerMovement and PlayerShooting components.
    /// </summary>
    void Death() {
        audioSource.clip = deathClip;
        audioSource.Play();

        isDead = true;
        anim.SetTrigger("Death");

        // Disable the components so the player can't move nor shoot
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (damaged) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
          }

        damaged = false;
    }


    /// <summary>
    /// This public function is called as an event in the Death animation. It calls the GameOver function of the GameManager to restart the level.
    /// </summary>
    public void RestartLevel() {
        gameManager.GameOver();
    }
}
