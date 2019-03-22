using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloco_Mover : MonoBehaviour {

	public Transform bloco;
	public bool activated = false, originBool = false;
	public Vector3 origin;
	public GameObject canv;
	[SerializeField] private InputField entrada;
	[SerializeField] private Dropdown dropdown;

	// Use this for initialization
	void Update(){
		if (activated) {
			if (!originBool) {
				originBool = true;
				origin = bloco.position;
			}
			command_move ();
		}
	}

	public void ActivatePlatform(){ activated = !activated; }

	public void command_move()
	{
		
		//float speed = float.Parse (entrada.text);
		Debug.Log ((bloco.position.y)+" > "+(origin.y + 1));
		if (bloco.position.y > origin.y + 1) {
			Debug.Log ("Chegou no destino");
			activated = false;
			originBool = false;
		}
		//Debug.Log (float.Parse(entrada.text));
		//moveSpeed = moveSpeed * 10000;
		//	Debug.Log ("enter in comannd move");
		if (dropdown.options[dropdown.value].text == "LEFT") 
		{
			bloco.Translate (Vector2.left * 0.5f * Time.deltaTime);
			Debug.Log ("moving left");
		}
		else if (dropdown.options[dropdown.value].text == "RIGHT") 
		{
			bloco.Translate (Vector2.right * 0.5f * Time.deltaTime);
				Debug.Log ("moving right");
		}
		else if (dropdown.options[dropdown.value].text == "UP") 
		{
			bloco.Translate (Vector2.up * 0.5f * Time.deltaTime);
			Debug.Log ("moving up");
		}
		else
		{
			bloco.Translate (Vector2.down * 0.5f *  Time.deltaTime);
			Debug.Log ("moving down");
		}			
	}

	public void deactivateCanvas(){ canv.SetActive (false);}
}
