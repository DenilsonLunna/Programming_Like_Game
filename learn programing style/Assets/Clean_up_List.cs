using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_up_List : MonoBehaviour
{
	public List<string> blocks = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       	for (int i = 0; i < transform.childCount; i++) if (transform.GetChild(i).gameObject.name == "New Game Object") Destroy (transform.GetChild(i).gameObject);
    }
}
