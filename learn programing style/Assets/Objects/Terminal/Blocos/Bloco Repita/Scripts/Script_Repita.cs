using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Repita : MonoBehaviour
{
    //Indicates if the script is running or not
    public bool running;
    // Panel where the childs are // object to execute the action
	[SerializeField] public Transform panel, obj;
    // childs of the panel
	public List <Transform> panelChilds = new List<Transform>();
    // how much should the object move on the X and Y axis
	public float xAxis, yAxis;
    // Tells the script when to start move, rotate, update the list of childs
	public bool startMove, startRotate, updateList, set, repita;
    // which direction the 'mova' or 'gurar' should act on
	public bool left, right, up, down;
    // number of repetitions // variable to control the distance 
	public int numRepeticoes, varControle;
    // holds the position where the obj started to move
	public Vector3 posOriginal;
    // aux variables
	public float posX, posY;
    public bool isExecuting;
    public Script_Testar arasta;
    public Script_Repita nestedRepita;
    public Transform parent;
	
    // Start is called before the first frame update
    void Start()
    {
        isExecuting = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!running) return;
        
        // Checks if some of the childs are 'mova' or 'girar'
    	for (int i = 0; i < panelChilds.Count ; i++){
            // if child(i) is 'mova', it makes the object move
            if (panelChilds[i] != null && panelChilds[i].gameObject.tag == "mova" && startMove && isExecuting)
            {
                // gets the script of the block 'move' to make the object move
                Script_Mover aux = panelChilds[i].GetComponent<Script_Mover>();
                aux.repita = this;
                Debug.Log(aux.gameObject.name);
                // gets the parameters of block repita and passes it to the block move
                //aux.SetupParameters();
                aux.ResetDirection(aux.dropdown.value);
                if(!aux.startMove) aux.AdjustParameters(startMove, aux.left, aux.right,aux.up,aux.down,numRepeticoes,varControle, posOriginal, obj);
                aux.startMove = true; aux.running = true;
                // basicly it says that, while isExecuting move the object, if not, stop moving and reset isExecuting to true
                isExecuting = aux.Move();
                if(!isExecuting) {startMove = isExecuting; running = false; aux.running = false; isExecuting = true;}
                arasta.running = !running;
            }
            // if child(i) is 'girar', it makes the object rotate
            if (panelChilds[i] != null && panelChilds[i].gameObject.tag == "girar" && startRotate && isExecuting)
            {
                if(obj != null){
                    // gets the script of the block 'girar' to make the object rotate
                    Script_Girar aux = panelChilds[i].GetComponent<Script_Girar>();
                    // basicly it says that, while isExecuting rotate the object, if not, stop rotating and reset isExecuting to true
                    
                    aux.parent = this.transform; aux.grandParent = this.parent; aux.numRepeticoes = numRepeticoes; 
                    if (numRepeticoes > 0){
                        aux.running = true;
                        running = aux.RotatePlatform(startRotate, aux.left, aux.right, numRepeticoes--);
                    }
                    
                    if(!isExecuting) {startRotate = isExecuting; running = false; aux.running = false; isExecuting = true;}
                    //arasta.running = running == true ? false : true;
                }
            }
            if (panelChilds[i] != null && panelChilds[i].gameObject.tag == "wqewq" )
            {
                if(obj != null){
                    // gets the script of the block 'girar' to make the object rotate
                    Script_Repita aux = panelChilds[i].GetComponent<Script_Repita>();
                    // basicly it says that, while isExecuting rotate the object, if not, stop rotating and reset isExecuting to true
                    running = true; aux.running = true;
                    isExecuting = aux.running;
                    
                }
            }
                
        }
        //Debug.Log(isExecuting+" "+startMove + " " +startRotate);
        // updates the list of childs
        if (updateList) UpdateList();
        // resets the current original position
        if (set) setPosOriginal();
    }

    public void Repita() {

    }

    // updates the list of childs
    public void UpdateList(){
    	panelChilds = new List<Transform>();
    	for (int i = 0; i < panel.childCount ; i++){
        	panelChilds.Add( panel.GetChild(i).transform );
        }
    }
    // resets the current original position
    public void setPosOriginal(){
        if (obj == null) return;
    	posOriginal = obj.position;
    	varControle = 0;
        //Script_Mover aux = obj.GetComponent<Script_Mover>();
        //aux.AdjustParameters(startMove, left, right, up, down, numRepeticoes, varControle, posOriginal, obj);
    }
}
