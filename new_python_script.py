import subprocess
import os

# import UnityEngine


def run_python_script(script_path):
    unity_python_path = os.path.abspath("C:\\Users\\LudusGlobal\\LudusSDK\\Library\\PythonInstall\\python.exe")
    # print("PATH:\t", sys.executable)

    # Build the command to run your script using the Unity Python interpreter
    command = [unity_python_path, script_path]

    # Run the command using subprocess
    result = subprocess.run(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE)

    # Print the output of the command
    out = result.stdout.decode()
    error = result.stderr.decode()

    if error is None:
        print("ERROR:\t", error)

    print("OUTPUT:\t", out)


def main():

    run_python_script(os.path.abspath("C:\\Users\\LudusGlobal\\Desktop\\Unity3D-python\\test.py"))


    '''
    all_game_objects = UnityEngine.Object.FindObjectsOfType(UnityEngine.GameObject)
    for game_object in all_game_objects:
        print(game_object)'''

if __name__ == '__main__':
    main()
