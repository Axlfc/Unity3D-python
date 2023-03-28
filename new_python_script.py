import subprocess
import platform
import sys
import os

import UnityEngine

unity_python_path = os.path.abspath("C:\\Users\\LudusGlobal\\LudusSDK\\Library\\PythonInstall\\python.exe")

print("PATH:\t", sys.executable)

# Build the command to run your script using the Unity Python interpreter
script_path = os.path.abspath("C:\\Users\\LudusGlobal\\Desktop\\csharp-unity3D-basic-scripting\\test.py")
command = [unity_python_path, script_path]

# Run the command using subprocess
result = subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE)

# Print the output of the command
out = result.stdout.decode()
error = result.stderr.decode()

if error is None:
    print("ERROR:\t", error)

print("OUTPUT:\t", out)



import numpy
print("NUMPY VERSION:\t", numpy.version.version)

'''
all_game_objects = UnityEngine.Object.FindObjectsOfType(UnityEngine.GameObject)
for game_object in all_game_objects:
    print(game_object)'''

