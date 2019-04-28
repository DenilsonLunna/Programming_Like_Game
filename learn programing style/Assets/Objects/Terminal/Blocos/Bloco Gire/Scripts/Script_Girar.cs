using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Girar : MonoBehaviour
{
    //Indicates if the script is running or not
    public bool running;
    // object to execute the action
    public Transform obj;
    // Tells the script when to start rotate
    public bool startRotate, left, right;

    public Script_Testar arasta;
    public Script_seEntao seEntao;
    public Transform parent, grandParent;
    public TMP_Dropdown dropdown;
    public int numRepeticoes;
    // Start is called before the first frame update
    void Update(){
        
        if (!running) return;
        if (dropdown.value == 0) {
            right = false; left = true; 
        }
        else {
            left = false; right = true; 
        }
        Debug.Log(numRepeticoes+" "+ (numRepeticoes > 0)+" "+running);
        if(numRepeticoes > 0) {
            running = true; 
            if (grandParent.gameObject.tag == "arasta") parent.GetComponent<Script_Repita>().running = true;
        }
        else {
            running = false;
            if (grandParent.gameObject.tag == "arasta") parent.GetComponent<Script_Repita>().running = false;
            if (grandParent.gameObject.tag == "arasta") grandParent.GetComponent<Script_Testar>().running = true;
        }
    }

    public bool RotatePlatform(bool startRotate, bool left, bool right, int numRepeticoes)
    {
        if (!running || numRepeticoes <= 0) return false;
        // if there is no obj or shouldn`t move, don`t run this code
        if (!startRotate || obj == null) return false;
        // if left, rotate to the left
        if (this.left) obj.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
        // if right, rotate to the right
        if (this.right) obj.Rotate(0.0f, 0.0f, -1.0f, Space.Self);
        // decrements the number of repetitions
        //if (this.left || this.right) numRepeticoes--;
        //Debug.Log(numRepeticoes + " " + (numRepeticoes != 0 ? true : false));

        // if number of repetitions different than 0, return true, else, return false
        running = numRepeticoes != 0 ? true : false;
        if (grandParent.gameObject.tag == "arasta")   arasta.running = running == true ? false : true;
        if (grandParent.gameObject.tag == "seEntao") seEntao.running = running == true ? false : true;
        //else Debug.Log(grandParent.gameObject.name+" "+grandParent.gameObject.tag);
        return numRepeticoes != 0 ? true : false;
    }
}
