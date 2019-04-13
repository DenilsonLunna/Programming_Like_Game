using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Girar : MonoBehaviour
{
    //Indicates if the script is running or not
    public bool running;
    // object to execute the action
    public Transform obj;
    // Tells the script when to start rotate
    public bool startRotate;
    // Start is called before the first frame update

    public bool RotatePlatform(bool startRotate, bool left, bool right, int numRepeticoes)
    {
        // if there is no obj or shouldn`t move, don`t run this code
        if (!startRotate || obj == null) return false;
        // if left, rotate to the left
        if (left) obj.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
        // if right, rotate to the right
        if (right) obj.Rotate(0.0f, 0.0f, -1.0f, Space.Self);
        // decrements the number of repetitions
        if (left || right) numRepeticoes--;
        Debug.Log(numRepeticoes + " " + (numRepeticoes != 0 ? true : false));

        // if number of repetitions different than 0, return true, else, return false
        return numRepeticoes != 0 ? true : false;
    }
}
