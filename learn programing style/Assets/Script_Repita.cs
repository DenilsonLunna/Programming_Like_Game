using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_Repita : MonoBehaviour
{
	[SerializeField] private Transform panel, platform;
	public List <Transform> panelChilds = new List<Transform>();
	public float timer, xAxis, yAxis;
	public bool startMove, updateList, set;
	public bool left, right, up, down;
	public int numRepeticoes, varControle;
	public Vector3 posOriginal;
	public float posX, posY;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	for (int i = 0; i < panelChilds.Count ; i++){
        	if (panelChilds[i] != null && panelChilds[i].gameObject.name == "mova" && startMove) 
        		Move();
        }
        
        if (updateList) UpdateList();
        if (set) setPosOriginal();
    }

    public void Move(){
    	if (left  && platform.position.x > posOriginal.x - numRepeticoes) platform.Translate(-xAxis, 0.0f, 0.0f); 
        if (right && platform.position.x < posOriginal.x + numRepeticoes) platform.Translate( xAxis, 0.0f, 0.0f); 
        if (up    && platform.position.y < posOriginal.y + numRepeticoes) platform.Translate( 0.0f,  yAxis, 0.0f); 
        if (down  && platform.position.y > posOriginal.y - numRepeticoes) platform.Translate( 0.0f, -yAxis, 0.0f);

        if (left || right) {
        	posX = System.Math.Abs (System.Math.Abs(posOriginal.x) - System.Math.Abs(platform.position.x));
        	if ((posX - varControle) >= 1) {Debug.Log("Instanciar +1"); varControle++;}
        }
    	if (up   || down ) {
    		posY = System.Math.Abs (System.Math.Abs(posOriginal.y) - System.Math.Abs(platform.position.y));
        	if(posY - varControle >= 1){Debug.Log("Instanciar +1"); varControle++;}
    	}
    	if (varControle == numRepeticoes) startMove = false;
    	//Debug.Log((posX - varControle)+" "+((posY - varControle) >= varControle)+" :::: "+(posY - varControle)+" "+((posX - varControle) >= varControle));
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
    }
}
