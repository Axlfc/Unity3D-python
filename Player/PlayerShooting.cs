using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    // This is going to be added as a Component in an empty GameObject in the tip of the gun of the player.
    public int damagePerShot;  // damage per shot that the player will do
    public float timeBetweenBullets;  // time between shots
    public float range;  // raycast length, which really means how far the player can shoot
    public LayerMask shootableMask;  // layer of objects to which we are going to be able to shoot

    float timer;  // variable that I am going to use as a time counter
    Ray ray;
    RaycastHit hit;
    LineRenderer lineRenderer;
    Light gunShotLight;
    float effectsDisplayTime = 0.2f;  // variable that will determine how long the effects will be on the screen


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        lineRenderer = GetComponent<LineRenderer>();
        gunShotLight = GetComponent<Light>();
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }


    /// <summary>
    /// Handles shooting behavior, including creating a visible line from the shooter to the target.
    /// </summary>
    void Shoot() {
        // reset timer
        timer = 0;
        // we enable the LineRenderer component and the Point Light
        lineRenderer.enabled = true;
        gunShotLight.enabled = true;
        // we set the first point of the LineRenderer
        lineRenderer.SetPosition(0, transform.position);

        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out hit, range, shootableMask)) {
            // Save in a local variable the gameobject we are hitting
            GameObject _object = hit.collider.gameObject;
            // Check if the gameobject is the enemy
            if (_object.GetComponent<EnemyHealth>()) {
                _object.GetComponent<EnemyHealth>().TakeDamage(damagePerShot);
            }


            lineRenderer.SetPosition(1, hit.point);
        } else lineRenderer.SetPosition(1, ray.origin + (ray.direction * range));  // set the second point of the lineRenderer to a range distance from the raycast origin
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        timer += Time.deltaTime;  // Time counter

        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets) {
            Shoot();
        }
        
        // Disabling effects
        if (timer >= timeBetweenBullets * effectsDisplayTime) {
            lineRenderer.enabled = false;
            gunShotLight.enabled = false;
        } 

    }
}
