using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teste_de_Tipos : MonoBehaviour
{
	public TMP_Dropdown dropdown;
	public TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.text != null){
        	int n;
        	bool isNumeric = int.TryParse(input.text, out n);
        	//Debug.Log(input.text+" "+input.text.GetType()+" "+isNumeric);	
        } 

    }
}
