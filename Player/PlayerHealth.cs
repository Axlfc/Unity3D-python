using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;

    public Slider slider;
    public Image damageImage;
    public Image healthImage;

    public float flashSpeed;  // the speed at which the image will disappear
    public Color flashColor;

    Animator anim;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
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
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    // public function that I am going to call from the enemy's script
    public void TakeDamage(int amount) {
        if (isDead) return;  // if the player dies the function is exited

        damaged = true;
        currentHealth -= amount;
        slider.value = currentHealth;
        healthImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0) Death();
    }


    void Death() {
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


    // Public function that goes as an event in the animation of Death
    public void RestartLevel() {
        Debug.Log("GAME OVER");
        // Game Over
    }
}
