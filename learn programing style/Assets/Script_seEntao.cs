using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_seEntao : MonoBehaviour
{
	public bool running;
	public Transform panel1, panel2;
	public List<Transform> panel1Childs = new List<Transform>();
	public List<Transform> panel2Childs = new List<Transform>();
	public int index;
	public bool condition, isIF_ELSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	UpdateList();
        if(running){
        	if (isIF_ELSE){
        		if (condition) ExecuteIF();
        		else ExecuteELSE();
        	}else if (condition) ExecuteIF();
        }
        if (condition && index == panel1.childCount) running = false;
        else if (!condition && index == panel2.childCount){running = false;} 
    }

 	public void UpdateList(){
 		panel1Childs = new List<Transform>();
 		panel2Childs = new List<Transform>(); 
    	for (int i = 0; i < panel1.childCount ; i++) panel1Childs.Add( panel1.GetChild(i).transform );
        for (int i = 0; i < panel2.childCount ; i++) panel2Childs.Add( panel2.GetChild(i).transform );
 	}

 	public void ExecuteIF(){
 		if (panel1 == null) return;
 		for (int i = index; i < panel1Childs.Count ; i++){
        	if ( panel1Childs[i].gameObject.tag == "mova"  ){
        		Debug.Log("Mova - IF");
        		ExecuteMover(1, i);
        		break;
        	}
        	if ( panel1Childs[i].gameObject.tag == "enquanto" ){
        		Script_Enquanto enquanto = panel1Childs[i].gameObject.GetComponent<Script_Enquanto>();
        		if (enquanto.obj == null) break;
        		index++;
        		enquanto.UpdateList();
        		enquanto.startMove = true ; enquanto.startRotate = true;
        		enquanto.condition = true;
        		enquanto.running = true;
        		running = false;
        		break;
        	}
        	if ( panel1Childs[i].gameObject.tag == "girar"    ){
        		Script_Girar girar = panel1Childs[i].gameObject.GetComponent<Script_Girar>();
        		if (girar.obj == null) break;
        		running = true; index++;
        	}
        	if ( panel1Childs[i].gameObject.tag == "repita"   ){
        		ExecuteRepita(1, i);
        		break;
        	}
        }
 	}
 	public void ExecuteELSE(){
 		if (panel2 == null) return;
		for (int i = index; i < panel2Childs.Count ; i++){
        	if ( panel2Childs[i].gameObject.tag == "mova"  ){
        		Debug.Log("Mova - ELSE");
        		ExecuteMover(2, i);
        		break;
        	}
        	if ( panel2Childs[i].gameObject.tag == "enquanto" ){
        		Script_Enquanto enquanto = panel2Childs[i].gameObject.GetComponent<Script_Enquanto>();
        		if (enquanto.obj == null) break;
        		index++;
        		enquanto.UpdateList();
        		enquanto.startMove = true ; enquanto.startRotate = true;
        		enquanto.condition = true;
        		enquanto.running = true;
        		running = false;
        		break;
        	}
        	if ( panel2Childs[i].gameObject.tag == "girar"    ){
        		Script_Girar girar = panel2Childs[i].gameObject.GetComponent<Script_Girar>();
        		if (girar.obj == null) break;
        		index++;
        	}
        	if ( panel2Childs[i].gameObject.tag == "repita"   ){
        		Debug.Log("Repita - ELSE");
        		ExecuteRepita(2, i);
        		break;
        	}
        }
 	}

 	private void ExecuteMover(int list, int i){
 		Script_Mover mova;
 		if (list == 1)   mova = panel1Childs[i].gameObject.GetComponent<Script_Mover>();
 		else mova = panel2Childs[i].gameObject.GetComponent<Script_Mover>();
	    if (mova.obj == null) return;
	    index++;
	    mova.SetupParameters();
    	//Get direction here
	    mova.up = true;
	    mova.running = true;
	    mova.startMoveSingle = true;
	    running = false;
 	}
 	private void ExecuteGirar(){

 	}
 	private void ExecuteRepita(int list, int i){
 		Script_Repita repita;
 		if (list == 1) repita = panel1Childs[i].gameObject.GetComponent<Script_Repita>();
	    else repita = panel2Childs[i].gameObject.GetComponent<Script_Repita>();
	    if (repita.obj == null) return;
	    index++;
	    // Pegar lista de filhos para setar direção e quantidade de repetições
	    //repita.right = true;
	    repita.parent = this.transform;
	    repita.numRepeticoes = 90;
	    repita.running = true;
	    repita.startRotate = true;
	    repita.startMove = true;
	    running = false;
 	}
}
