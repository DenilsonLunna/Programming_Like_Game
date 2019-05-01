using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enquanto : MonoBehaviour
{
    //Indicates if the script is running or not
    public bool running;
    // Panel where the childs are // object to execute the action
	public Transform panel, obj;
    // childs of the panel
	public List <Transform> panelChilds = new List<Transform>();
    // how much should the object move on the X and Y axis
	public float timer, angle, xAxis, yAxis;
    // Tells the script when to start move, rotate, update the list of childs
	public bool startRotate, startMove, updateList, condition;
	public Script_Testar arasta;
    // Start is called before the first frame update
    void Start()
    {
        startRotate = false;
        panelChilds = new List<Transform>();
        condition = true;
    }

    // Update is called once per frame
    void Update()
    {

    	if (!running) return;
        arasta.running = running == true ? false : true;
    	// Checks if some of the childs are 'mova' or 'girar'
        if (condition){
        	for (int i = 0; i < panelChilds.Count ; i++){
	            // rotates the object while startRotate is true
	        	if (panelChilds[i] != null && panelChilds[i].gameObject.name == "girar" && startRotate) 
	        		obj.Rotate(0.0f, 0.0f, angle, Space.Self);
	            // moves the object while startMove is true
	        	if (panelChilds[i] != null && panelChilds[i].gameObject.name == "mova" && startMove) 
	        		obj.Translate(xAxis, yAxis, 0.0f, Space.World);
        	}
        }else if (!condition) {
        	running = false; arasta.running = running == true ? false : true;
        }
        
        // updates the list of childs
        if (updateList) UpdateList();
    }

    public void UpdateList(){
    	panelChilds = new List<Transform>();
    	for (int i = 0; i < panel.childCount ; i++){
        	panelChilds.Add( panel.GetChild(i).transform );
        }
    }

    public void SetPanelChild(){
    	//panelChild = panel.GetChild(0);
    }

}
