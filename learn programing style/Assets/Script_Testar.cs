using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Testar : MonoBehaviour
{
	public Transform arasta;
	public List <Transform> arastaChilds = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	UpdateList();
        for (int i = 0; i < arastaChilds.Count ; i++){

        }
    }

    public void UpdateList(){
    	arastaChilds = new List<Transform>();
    	for (int i = 0; i < arasta.childCount ; i++){
        	arastaChilds.Add( arasta.GetChild(i).transform );
        }
    }
}
