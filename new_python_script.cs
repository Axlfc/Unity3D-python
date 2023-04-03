using UnityEditor;
using UnityEditor.Scripting.Python;

public class MenuItem_NewPythonScript_Class
{
   [MenuItem("Python Scripts/NewPythonScript")]
   public static void NewPythonScript()
   {
       PythonRunner.RunFile("Assets/Scripts/new_python_script.py");
       }
};
