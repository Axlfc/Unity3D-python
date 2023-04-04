using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    GameObject player;
    NavMeshAgent agent;
    Animator anim;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    /// <summary>
    /// This function updates the "IsMoving" boolean parameter of the animator component based on the magnitude of the agent's velocity.
    /// </summary>
    void Animating() {
        if (agent.velocity.magnitude != 0) {
            anim.SetBool("IsMoving", true);
        } else anim.SetBool("IsMoving", false);
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (player != null) {
            agent.SetDestination(player.transform.position);
        }
        Animating();
    }
}
