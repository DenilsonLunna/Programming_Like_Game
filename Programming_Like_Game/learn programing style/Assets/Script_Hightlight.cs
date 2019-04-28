using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Hightlight : MonoBehaviour
{
    public Behaviour halo;
    public GameObject terminal;
    private GameObject seEntao;
    [SerializeField] private Script_Mover mova; 
    [SerializeField] private Script_Girar girar;
    [SerializeField] private Script_Enquanto enquanto;
    [SerializeField] private Script_Repita repita;

    void Start(){
    	//seEntao = GameObject.Find("seEntao").GetComponent<Script_>();
    	mova     = GameObject.Find("mova").GetComponent<Script_Mover>();
    	girar    = GameObject.Find("girar").GetComponent<Script_Girar>();
    	enquanto = GameObject.Find("enquanto").GetComponent<Script_Enquanto>();
    	repita   = GameObject.Find("repita").GetComponent<Script_Repita>();
    }

    void OnMouseEnter()
    {
        halo.enabled = true;

    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
       halo.enabled = false;
    }

    void OnMouseDown()
    {
        terminal.SetActive(true);
        SetupVariables();
    }

    private void SetupVariables(){
    	repita.obj = transform;
    	enquanto.obj = transform;
    	mova.obj = transform;
    	girar.obj = transform;
    }
}