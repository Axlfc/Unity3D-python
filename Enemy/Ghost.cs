using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour {
    public Transform[] waypoints;
    public GameObject player;
    public LayerMask playerLayer;

    Ray ray;
    RaycastHit hit;
    NavMeshAgent agent;

    Vector3 postToGo;

    int m_CurrentWaypointIndex;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables()
    {
        agent = GetComponent<NavMeshAgent>();
        postToGo = waypoints[0].position;
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
        
    }


    ///<summary>
    ///Change the position of the game object to the next waypoint position in the array.
    ///If the distance to the waypoint is less than 0.1f, move to the next waypoint position.
    ///</summary>
    void ChangePosition() {
        if (Vector3.Distance(transform.position, postToGo) < 0.1f) {
            if (m_CurrentWaypointIndex == waypoints.Length -1) m_CurrentWaypointIndex = 0;
            else m_CurrentWaypointIndex++;

            postToGo = waypoints[m_CurrentWaypointIndex].position;
        }
    }

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        agent.SetDestination(postToGo);
        ChangePosition();
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate() {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out hit)) {
            if(hit.collider.CompareTag("Player")) {
                Debug.Log("Catching Player");
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
;    }
}
