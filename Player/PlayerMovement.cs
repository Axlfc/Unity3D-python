using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int speed;
    public LayerMask layerFloor;  // layer where the floor of the scene will be

    Rigidbody rb;
    Animator anim;
    Vector3 movement;
    float horizontal;
    float vertical;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        InitializeVariables();
    }



    /// <summary>
    /// Reads the input values for horizontal and vertical axes.
    /// </summary>
    void InputPlayer() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        InputPlayer();
    }


    /// <summary>
    /// Moves the object based on input from the input of the player.
    /// Normalizes the input to ensure consistent movement, multiplies by speed and deltaTime,
    /// and uses Rigidbody.MovePosition to update the object's position.
    /// </summary>
    void Move() {
        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }


    /// <summary>
    /// This function calculates the rotation of the player towards the position of the mouse cursor on the screen.
    /// A raycast is used to project a ray from the camera to the floor to determine the position of the mouse cursor in 3D space.
    /// The player rotates towards the mouse cursor position by applying the calculated rotation to the Rigidbody.
    /// </summary>
    void Turning() {
        // Raycast that goes from the mouse cursor in screen coordinates and towards the scene
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerFloor)) {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            // We calculate the rotation
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Apply rotation, i.e. rotate the object
            rb.MoveRotation(newRotation);
        }
        // Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
    }


    /// <summary>
    /// Updates the "IsMoving" boolean parameter of an Animator component based on the current values of the "horizontal" and "vertical" input axes.
    /// </summary>
    void Animating() {
        // if horizontal is nonzero or vertical is nonzero
        if (horizontal != 0 || vertical != 0) {
            anim.SetBool("IsMoving", true);
        } else anim.SetBool("IsMoving", false);  // both are zero
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
        Move();
        Turning();
        Animating();
    }
}
