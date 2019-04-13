using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Repita : MonoBehaviour
{
	[SerializeField] public Transform panel, platform;
	public List <Transform> panelChilds = new List<Transform>();
	public float timer, xAxis, yAxis;
	public bool startMove, startRotate, updateList, set, repita;
	public bool left, right, up, down;
	public int numRepeticoes, varControle;
	public Vector3 posOriginal;
	public float posX, posY;
    public bool isExecuting;
    public GameObject obj;
	
    // Start is called before the first frame update
    void Start()
    {
        isExecuting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!repita) return;

    	for (int i = 0; i < panelChilds.Count ; i++){
            if (panelChilds[i] != null && panelChilds[i].gameObject.name == "mova" && startMove && isExecuting)
            {
                Script_Mover aux = panelChilds[i].GetComponent<Script_Mover>();
                if(!aux.startMove) aux.AdjustParameters(startMove, left, right,up,down,numRepeticoes,varControle, posOriginal, platform);
                aux.startMove = true;
                //Debug.Log(aux.varControle);
                isExecuting = aux.Move();
                
                if(!isExecuting) {startMove = isExecuting; isExecuting = true;}
            }
            if (panelChilds[i] != null && panelChilds[i].gameObject.name == "girar" && startRotate && !isExecuting)
            {
                Script_Girar aux = platform.gameObject.GetComponent<Script_Girar>();
                isExecuting = aux.RotatePlatform(startRotate, left, right, numRepeticoes--);
            }
                
        }
        //Debug.Log(isExecuting+" "+startMove + " " +startRotate);
        if (updateList) UpdateList();
        if (set) setPosOriginal();
    }

    public void Repita() {

    }

    public void UpdateList(){
    	panelChilds = new List<Transform>();
    	for (int i = 0; i < panel.childCount ; i++){
        	panelChilds.Add( panel.GetChild(i).transform );
        }
    }

    public void setPosOriginal(){
    	posOriginal = platform.position;
    	varControle = 0;
        //Script_Mover aux = platform.GetComponent<Script_Mover>();
        //aux.AdjustParameters(startMove, left, right, up, down, numRepeticoes, varControle, posOriginal, platform);
    }
}
