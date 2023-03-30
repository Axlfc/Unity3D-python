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


    void ChangePosition(float destination_xPos, float destination_yPos, float destination_zPos) {
        transform.position = new Vector3(destination_xPos, destination_yPos, destination_zPos);
    }

    void ChangePositionX(float destination_xPos)
    {
        transform.position = new Vector3(destination_xPos, transform.position.y, transform.position.z);
    }

    void ChangePositionY(float destination_yPos)
    {
        transform.position = new Vector3(transform.position.x, destination_yPos, transform.position.z);
    }

    void ChangePositionZ(float destination_zPos)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, destination_zPos);
    }
    

    // Description: print (Like in Python)
    void print(params object[] args) {
        string message = "";
        foreach (object arg in args) { message += arg.ToString() + " ";}
        UnityEngine.Debug.Log(message);
    }


    // Description: Run local python script file
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
    
    
    // Description: InitializeVariables is called to set values to the variables
    void InitializeVariables() {
        // life = 100f;
        // jumpForce = 50.5f;
        // playerName = "Mikel";
        speed = 8;
        turnSpeed = 100;

        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }


    // References to the components.
    void Awake() {

    }


    // Description: Start is called before the first frame update
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


    void TranslatePositionForward() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void TranslatePositionBackward() {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    void TranslatePositionUp() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void TranslatePositionRight() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }


    void RotatePositionUp() {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }

    void RotatePositionDown()
    {
        transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
    }

    void RotatePositionRight() {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

    void RotatePositionLeft()
    {
        transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
    }

    void RotatePositionForward() {
        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);
    }

    void RotatePositionBackward()
    {
        transform.Rotate(-Vector3.right * turnSpeed * Time.deltaTime);
    }



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


    // Description: Update is called once per frame
    void Update() {
        PressKey("W");
        PressKey("A");
        PressKey("S");
        PressKey("D");

        PressKey("E");

    }


    // Move physics of the object using the rigidbody
    void FixedUpdate() {

    }
}
