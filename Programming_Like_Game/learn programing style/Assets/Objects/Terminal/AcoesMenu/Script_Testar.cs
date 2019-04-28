using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Testar : MonoBehaviour
{
	public Transform arasta;
	public List <Transform> arastaChilds = new List<Transform>();
    public int index;
    public bool running;
	public GameObject terminal;

    // Start is called before the first frame update
    void Start()
    {
        index   = 0;
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
    	UpdateList();
    	if (running){
    		for (int i = index; i < arastaChilds.Count ; i++){
	        	if ( arastaChilds[i].gameObject.name == "mova"  ){
	        		Script_Mover mova = arastaChilds[i].gameObject.GetComponent<Script_Mover>();
	        		if (mova.obj == null) break;
	        		index++;
	        		mova.SetupParameters();
	        		//Get direction here
	        		mova.up = true;
	        		mova.running = true;
	        		mova.startMoveSingle = true;
	        		running = false;
	        		break;
	        	}
	        	if ( arastaChilds[i].gameObject.name == "enquanto" ){
	        		Script_Enquanto enquanto = arastaChilds[i].gameObject.GetComponent<Script_Enquanto>();
	        		if (enquanto.obj == null) break;
	        		running = true; index++;
	        		enquanto.UpdateList();
	        		enquanto.startMove = true ; enquanto.startRotate = true;
	        		enquanto.condition = true;
	        		enquanto.running = true;
	        		running = false;
	        		break;
	        	}
	        	if ( arastaChilds[i].gameObject.name == "girar"    ){
	        		Script_Girar girar = arastaChilds[i].gameObject.GetComponent<Script_Girar>();
	        		if (girar.obj == null) break;
	        		running = true; index++;
	        	}
	        	if ( arastaChilds[i].gameObject.name == "repita"   ){
	        		Script_Repita repita = arastaChilds[i].gameObject.GetComponent<Script_Repita>();
	        		if (repita.obj == null) break;
	        		running = true; index++;
	        		// Pegar lista de filhos para setar direção e quantidade de repetições
	        		//repita.right = true;
	        		repita.numRepeticoes = 90;
	        		repita.running = true;
	        		repita.startRotate = true;
	        		repita.startMove = true;
	        		running = false;
	        		break;
	        	}
	        	if ( arastaChilds[i].gameObject.name == "declare"  ); 
	        }	
    	}
    	if (index == arastaChilds.Count) UpdateList();
    }

    public void ResetIndex(){
    	index = 0;
    }

    public void StartRunning(){ 
		terminal.SetActive (false);
		running = true; 
	}

    public void UpdateList(){
    	arastaChilds = new List<Transform>();
    	for (int i = 0; i < arasta.childCount ; i++){
        	arastaChilds.Add( arasta.GetChild(i).transform );
        }
    }
}
