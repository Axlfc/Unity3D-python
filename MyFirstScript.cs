using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Scripting.Python;
using UnityEngine;


public class MyFirstScript : MonoBehaviour {
    // Variables Declaration
    float life;
    float jumpForce;
    string playerName;

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



    // Description: InitializeVariables is called to set values to the variables
    void InitializeVariables() {
        // life = 100f;
        // jumpForce = 50.5f;
        // playerName = "Mikel";

        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
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


    // Description: Start is called before the first frame update
    void Start() {
        // print($"The name of the player is:\t{playerName}");
        // print("The value of life is:\t" + life);
        // print("The jump force is:\t", jumpForce);

        InitializeVariables();
        print($"The position in x is:\t{xPos}");
        print($"The position in y is:\t{yPos}");
        print($"The position in z is:\t{zPos}");


        // This is running with the Python of the system, which has no numpy
        // RunLocalPythonFile("C:\\Users\\LudusGlobal\\LudusSDK\\Assets\\Scripts\\new_python_script.py");




    }


    // Description: Update is called once per frame
    void Update() {

    }
}
