using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEditor.Scripting.Python;
using UnityEngine;


public class MyFirstScript : MonoBehaviour {
    // Variables Declaration
    float life;
    float jumpForce;
    string playerName;
    public int speed;
    public int turnSpeed;
    
    float xPos;
    float yPos;
    float zPos;


    /// <summary>
    /// Initializes variables
    /// </summary>
    void InitializeVariables()
    {
        // life = 100f;
        // jumpForce = 50.5f;
        // playerName = "Mikel";
        speed = 8;
        turnSpeed = 100;

        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {

    }


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start() {
        // print($"The name of the player is:\t{playerName}");
        // print("The value of life is:\t" + life);
        // print("The jump force is:\t", jumpForce);

        InitializeVariables();

        //print($"The position in x is:\t{xPos}");
        //print($"The position in y is:\t{yPos}");
        //print($"The position in z is:\t{zPos}");


        // This is running with the Python of the system, which has no numpy
        // RunLocalPythonFile("C:\\Users\\LudusGlobal\\LudusSDK\\Assets\\Scripts\\new_python_script.py");

    }


    /// <summary>
    /// Changes the position of the GameObject to the specified x, y, and z coordinates.
    /// </summary>
    /// <param name="destination_xPos">The destination x position.</param>
    /// <param name="destination_yPos">The destination y position.</param>
    /// <param name="destination_zPos">The destination z position.</param>
    void ChangePosition(float destination_xPos, float destination_yPos, float destination_zPos) {
        transform.position = new Vector3(destination_xPos, destination_yPos, destination_zPos);
    }


    /// <summary>
    /// Changes the x position of the GameObject to the specified value while preserving the y and z positions.
    /// </summary>
    /// <param name="destination_xPos">The destination x position.</param>
    void ChangePositionX(float destination_xPos) {
        transform.position = new Vector3(destination_xPos, transform.position.y, transform.position.z);
    }

    /// <summary>
    /// Changes the y position of the GameObject to the specified value while preserving the x and z positions.
    /// </summary>
    /// <param name="destination_yPos">The destination y position.</param>
    void ChangePositionY(float destination_yPos) {
        transform.position = new Vector3(transform.position.x, destination_yPos, transform.position.z);
    }

    /// <summary>
    /// Changes the z position of the GameObject to the specified value while preserving the x and y positions.
    /// </summary>
    /// <param name="destination_zPos">The destination z position.</param>
    void ChangePositionZ(float destination_zPos) {
        transform.position = new Vector3(transform.position.x, transform.position.y, destination_zPos);
    }


    /// <summary>
    /// A pythonic implementation of the print function, which concatenates a string from the given arguments and logs it to the console.
    /// </summary>
    /// <param name="args">The arguments to concatenate into a string and print.</param>
    void print(params object[] args) {
        string message = "";
        foreach (object arg in args) { message += arg.ToString() + " ";}
        UnityEngine.Debug.Log(message);
    }

    /// <summary>
    /// Runs a local Python file using the command-line 'python' interpreter.
    /// </summary>
    /// <param name="filePath">The path to the Python file to be executed.</param>
    void RunLocalPythonFile(string filePath) {
        Process process = new Process();
        process.StartInfo.FileName = "python";
        process.StartInfo.Arguments = filePath;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string errors = process.StandardError.ReadToEnd();
        process.WaitForExit();
        print($"LOCAL PYTHON OUTPUT:\t{output}");
        print($"LOCAL PYTHON ERRORS:\t{errors}");
    }


    /// <summary>
    /// Translates the transform forward by speed units per second.
    /// </summary>
    void TranslatePositionForward() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// Translates the transform backward by speed units per second.
    /// </summary>
    void TranslatePositionBackward() {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// Translates the transform up by speed units per second.
    /// </summary>
    void TranslatePositionUp() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// Translates the transform right by speed units per second.
    /// </summary>
    void TranslatePositionRight() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform up by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionUp() {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform down by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionDown() {
        transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform right by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionRight() {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform left by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionLeft() {
        transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform forward by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionForward() {
        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the transform backward by turnSpeed degrees per second.
    /// </summary>
    void RotatePositionBackward() {
        transform.Rotate(-Vector3.right * turnSpeed * Time.deltaTime);
    }


    /// <summary>
    /// Handles key press, hold and release events.
    /// </summary>
    /// <param name="keyName">The name of the key to handle.</param>
    void PressKey(string keyName) {
        if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), keyName)))
        {
            if (keyName == "E")
            {
                print("E pressing on");
            }
        }

        if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keyName)))
        {
            if (keyName == "W")
            {
                TranslatePositionForward();
            }
            else if (keyName == "S")
            {
                TranslatePositionBackward();
            }

            if (keyName == "D") {
                RotatePositionRight();
            }
            else if (keyName == "A") {
                RotatePositionLeft();
            }

            if (keyName == "E") {
                print("E has been pressed");
            }

        } else if (Input.GetKeyUp((KeyCode)Enum.Parse(typeof(KeyCode), keyName)))
          {
            if (keyName == "E")
            {
                print("E pressing off");
            }
          }
    }

    /// <summary>
    /// Presses the given list of keyNames
    /// </summary>
    /// <param name="keyNames">Array of keyNames to be pressed</param>
    void PressKeys(params string[] keyNames) {
        foreach (string keyName in keyNames) {
            PressKey(keyName);
        }
    }


    /// <summary>
    /// Presses a specified button and prints messages when the button is pressed, held down or released.
    /// </summary>
    /// <param name="buttonName">The name of the button to press.</param>
    void PressButton(string buttonName) {
        if (Input.GetButtonDown(buttonName)) {
            if (buttonName == "Fire1") {
                print("Fire1 (Left Mouse Button) Down!!");
            }
        }

        if (Input.GetButton(buttonName)) {
            if (buttonName == "Fire1") {
                print("Fire1 (Left Mouse Button)!!");
            }
        } else if (Input.GetButtonUp(buttonName)) {
            if (buttonName == "Fire1") {
                print("Fire1 (Left Mouse Button) Up!!");
            }
        }
    }

    /// <summary>
    /// Presses the specified buttons, triggering their corresponding events if they are pressed down or released
    /// </summary>
    /// <param name="buttonNames">The names of the buttons to press</param>
    void PressButtons(params string[] buttonNames) {
        foreach (string buttonName in buttonNames)
        {
            PressButton(buttonName);
        }
    }


    /// <summary>
    /// Moves the game object in the vertical axis based on input.
    /// </summary>
    /// <param name="vertical">The input value for the vertical axis.</param>
    void MoveInVerticalAxis(float vertical) {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
    }

    /// <summary>
    /// Rotates the game object in the horizontal axis based on input.
    /// </summary>
    /// <param name="horizontal">The input value for the horizontal axis.</param>
    void MoveInHorizontalAxis(float horizontal) {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontal);
    }


    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        // Capture the vertical/horizontal axis inputs
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        MoveInVerticalAxis(vertical);
        MoveInHorizontalAxis(horizontal);

        PressKey("E");
        // PressKeys("W", "A", "S", "D");

        // PressButtons("Fire1");
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {

    }
}
