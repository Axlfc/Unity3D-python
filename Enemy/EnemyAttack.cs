using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public float timeBetweenAttacks;
    public int attackDamage;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        enemyHealth = GetComponent<EnemyHealth>();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) playerInRange = true; 
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player) playerInRange = false;
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    void Attack() {
        timer = 0;
        playerHealth.TakeDamage(attackDamage);
    }

    /// <summary>
    /// Called every fra
    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.isDead == false) Attack();
    }
}
