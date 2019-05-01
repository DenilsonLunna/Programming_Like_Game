using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Testar : MonoBehaviour
{
	public bool running;
	public Transform arasta;
	public List <Transform> arastaChilds = new List<Transform>();
    public int index;
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
	        	Debug.Log("----------------------- "+i+" ----------------------- ");
	        	if ( arastaChilds[i].gameObject.tag == "mova"  ){
	        		Debug.Log("Testar - Mova");
	        		Script_Mover mova = arastaChilds[i].gameObject.GetComponent<Script_Mover>();
	        		if (mova.obj == null) break;
	        		index++;
	        		mova.SetupParameters();
	        		//Get direction here
	        		//mova.up = true;
	        		mova.running = true;
	        		mova.startMoveSingle = true;
	        		running = false;
	        		break;
	        	}
	        	if ( arastaChilds[i].gameObject.tag == "enquanto" ){
	        		Script_Enquanto enquanto = arastaChilds[i].gameObject.GetComponent<Script_Enquanto>();
	        		if (enquanto.obj == null) break;
	        		index++;
	        		enquanto.UpdateList();
	        		enquanto.startMove = true ; enquanto.startRotate = true;
	        		enquanto.condition = true;
	        		enquanto.running = true;
	        		running = false;
	        		break;
	        	}
	        	if ( arastaChilds[i].gameObject.tag == "girar"    ){
	        		Script_Girar girar = arastaChilds[i].gameObject.GetComponent<Script_Girar>();
	        		if (girar.obj == null) break;
	        		running = true; index++;
	        	}
	        	if ( arastaChilds[i].gameObject.tag == "repita"   ){
	        		
	        		Script_Repita repita = arastaChilds[i].gameObject.GetComponent<Script_Repita>();
	        		Debug.Log("Testar - Repita "+repita.gameObject.name);
	        		if (repita.obj == null) break;
	        		index++;

	        		// Pegar lista de filhos para setar direção e quantidade de repetições
	        		//repita.right = true;
	        		repita.parent = this.transform;
	        		repita.numRepeticoes = 2;
	        		repita.running = true;
	        		repita.startRotate = true;
	        		repita.startMove = true;
	        		repita.isExecuting = true;
	        		running = false;
	        		break;
	        	}
	        	
	        	if ( arastaChilds[i].gameObject.tag == "seEntao"  ){
	        		Debug.Log("Testar - seEntao");
	        		Script_seEntao seEntao = arastaChilds[i].gameObject.GetComponent<Script_seEntao>();
	        		seEntao.index = 0; seEntao.running = true;
	        		index++; running = false;
	        		break;
	        	}
	        }	
    	}
    	if (index == arastaChilds.Count) {UpdateList(); running = false; }
    }

    public void ResetIndex(){
    	index = 0;
    }

    public void StartRunning(){ 
		//terminal.SetActive (false);
		ResetIndex();
		running = true; 
	}

    public void UpdateList(){
    	arastaChilds = new List<Transform>();
    	for (int i = 0; i < arasta.childCount ; i++){
        	arastaChilds.Add( arasta.GetChild(i).transform );
        }
    }
}
