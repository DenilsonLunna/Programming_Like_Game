using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChild : MonoBehaviour
{
	


	private GameObject target ;



	void Start(){
		target = null;

	}

	void OnTriggerStay2D(Collider2D col){
		target = col.gameObject;
		target.transform.parent = this.transform;

	}

	void OnTriggerExit2D(Collider2D col){
		target.transform.parent = null;

	
	}


}


