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
	public GameObject light;
	// temporary highlight
	//public Behaviour halo;
	// reference to the terminal
	public GameObject terminal;
    private bool set = false;

    // Start is called before the first frame update
    void Start()
    {
		light.SetActive (false);
    	// finds the objects and sets the apropriated script
        //enquanto = GameObject.Find("enquanto").GetComponent<Script_Enquanto>();
        //mova     = GameObject.Find("mova").GetComponent<Script_Mover>();
        //girar    = GameObject.Find("girar").GetComponent<Script_Girar>();
        //repita   = GameObject.Find("repita").GetComponent<Script_Repita>();
        //terminal.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (terminal.activeInHierarchy && set) {
            mova     = GameObject.Find("mova").GetComponent<Script_Mover>();
            girar    = GameObject.Find("girar").GetComponent<Script_Girar>();
            repita   = GameObject.Find("repita").GetComponent<Script_Repita>();
            SetupVariables();
            set = false;
        }else return;
    }
    void OnMouseEnter(){
    	// enables halo
		light.SetActive (true);

    }

    void OnMouseExit(){
    	// disables halo
		light.SetActive (false);
    }	

    void OnMouseDown(){
    	// enables terminal
		if(!terminal.activeSelf){
			terminal.SetActive(true);	
		}
    	
        set = true;
    	// changes the object of every block to the current object that opened the terminal
    	
    }
    
	// changes the object of every block to the current object that opened the terminal
    private void SetupVariables(){
    	//enquanto.obj = transform;
    	mova.obj = transform;
    	girar.obj = transform;
    	repita.obj = transform;
    }
}
