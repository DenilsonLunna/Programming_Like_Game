using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Girar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RotatePlatform(bool startRotate, bool left, bool right, int numRepeticoes)
    {
        if (!startRotate) return false;
        if (left) transform.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
        if (right) transform.Rotate(0.0f, 0.0f, -1.0f, Space.Self);
        if (left || right) numRepeticoes--;
        Debug.Log(numRepeticoes + " " + (left || right));

        return numRepeticoes != 0 ? true : false;
    }
}
