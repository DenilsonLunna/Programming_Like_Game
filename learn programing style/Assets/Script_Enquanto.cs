using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enquanto : MonoBehaviour
{
	[SerializeField] private Transform panel, fan;
	public List <Transform> panelChilds = new List<Transform>();
	public float timer, angle, xAxis, yAxis;
	public bool startRotate, startMove, updateList;
	
    // Start is called before the first frame update
    void Start()
    {
        startRotate = false;
        panelChilds = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    	
        for (int i = 0; i < panelChilds.Count ; i++){
        	if (panelChilds[i] != null && panelChilds[i].gameObject.name == "girar" && startRotate) 
        		fan.Rotate(0.0f, 0.0f, angle, Space.Self);
        	if (panelChilds[i] != null && panelChilds[i].gameObject.name == "girar" && startMove) 
        		fan.Translate(xAxis, yAxis, 0.0f);
        	
        }
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
