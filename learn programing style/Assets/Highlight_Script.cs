using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight_Script : MonoBehaviour
{
	
	public Behaviour halo;
	public GameObject terminal;
    void OnMouseEnter()
    {
		halo.enabled = true;
    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        //Debug.Log("Sobre!");
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
		halo.enabled = false;
    }

    void OnMouseDown()
    {
		terminal.SetActive (true);
    }
}
