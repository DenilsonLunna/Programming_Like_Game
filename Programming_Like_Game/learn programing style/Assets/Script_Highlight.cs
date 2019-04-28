using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Highlight : MonoBehaviour
{
	// reference to the blocks
	[SerializeField] private Script_Enquanto enquanto;
	[SerializeField] private Script_Mover mova;
	[SerializeField] private Script_Girar girar;
	[SerializeField] private Script_Repita repita;
	// temporary highlight
	public Behaviour halo;
	// reference to the terminal
	public GameObject terminal;

    // Start is called before the first frame update
    void Start()
    {
    	// finds the objects and sets the apropriated script
        enquanto = GameObject.Find("enquanto").GetComponent<Script_Enquanto>();
        mova     = GameObject.Find("mova").GetComponent<Script_Mover>();
        girar    = GameObject.Find("girar").GetComponent<Script_Girar>();
        repita   = GameObject.Find("repita").GetComponent<Script_Repita>();
    }

    // Update is called once per frame
    void OnMouseEnter(){
    	// enables halo
    	halo.enabled = true;
    }

    void OnMouseExit(){
    	// disables halo
    	halo.enabled = false;
    }	

    void OnMouseDown(){
    	// enables terminal
    	terminal.SetActive(true);
    	// changes the object of every block to the current object that opened the terminal
    	SetupVariables();
    }
    
	// changes the object of every block to the current object that opened the terminal
    private void SetupVariables(){
    	enquanto.obj = transform;
    	mova.obj = transform;
    	girar.obj = transform;
    	repita.obj = transform;
    }
}
