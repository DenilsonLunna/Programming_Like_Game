using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Options_Control_seEntao : MonoBehaviour
{
    public TMP_Dropdown variables, comparassion, booleanValue;
    public TMP_InputField numericInput;
    private List<string> m_BooleanComparassion = new List<string> {"==","!="};
    private List<string> m_NumericComparassion = new List<string> {"==","!=",">","<",">=","<="};
    [SerializeField] private Script_seEntao seEntao;
    private bool ligado = true;
    private float num;

    void Start(){
    	if (variables != null || comparassion != null || booleanValue != null || numericInput != null)
    		SetCondition();
    }

    public void SetCondition(){
    	bool c;
    	int n;
    	switch(comparassion.value){
    		case 0:
    			//Debug.Log(ligado.GetType()+" "+booleanValue.itemText.GetType()+" "+booleanValue.captionText.text);
    			if (booleanValue.gameObject.activeInHierarchy)
    				ParseToBool("==");
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt("==");
    			break;
    		case 1:
    			if (booleanValue.gameObject.activeInHierarchy)
    				ParseToBool("!=");
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt("!=");
    			break;
    		case 2:
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt(">");
    			break;
    		case 3:
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt("<");
    			break;
    		case 4:
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt(">=");
    			break;
    		case 5:
    			if (numericInput.gameObject.activeInHierarchy)
    				ParseToInt("<=");
    			break;
    	}
    }

    private void ParseToBool(string condition){
    	bool c;
    	if (Boolean.TryParse(booleanValue.captionText.text, out c)){
			switch(condition){
				case "==":
					if (ligado == c) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case "!=":
					if (ligado != c) seEntao.condition = true;
					else seEntao.condition = false;
					break;	
			}
		}
	}

    private void ParseToInt(string condition){
    	int n;
    	if (int.TryParse(numericInput.text, out n)){
			switch(condition){
				case "==":
					if (num == n) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case "!=":
					if (num != n) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case ">":
					if (num > n) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case "<":
					if (num < n) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case ">=":
					if (num >= n) seEntao.condition = true;
					else seEntao.condition = false;
					break;
				case "<=":
					if (num <= n) seEntao.condition = true;
					else seEntao.condition = false;
					break;	
			}
		}
    }

    public void ChangeOptions(){
    	if (variables == null || comparassion == null || booleanValue == null || numericInput == null) 
        	return;
        switch (variables.value){
        	case 0: 
        		comparassion.ClearOptions();
        		booleanValue.gameObject.SetActive(true);
        		numericInput.gameObject.SetActive(false);
        		comparassion.AddOptions(m_BooleanComparassion);
        		break;
        	case 1:
        		comparassion.ClearOptions();
        		booleanValue.gameObject.SetActive(false);
        		numericInput.gameObject.SetActive(true);
        		comparassion.AddOptions(m_NumericComparassion);
        		break;
        }
    }
}
