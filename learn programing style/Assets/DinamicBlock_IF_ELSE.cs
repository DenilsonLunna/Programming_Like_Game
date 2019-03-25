using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicBlock_IF_ELSE : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject base2, rabo1, rabo2;
    [SerializeField] private RectTransform rectTr, buttonRect;
    
    public void switchStyle_IF_ELSE(){
        bool activeSelf = rabo1.activeSelf;
        Debug.Log(message: "Base2: " + base2.activeSelf+", rabo1: "+ activeSelf + ", rabo2: " + rabo2.activeSelf);

        base2.SetActive(!base2.activeSelf);
        rabo1.SetActive(!rabo1.activeSelf);
        rabo2.SetActive(!rabo2.activeSelf);

        if(!activeSelf) rectTr.sizeDelta = new Vector2(rectTr.rect.width,182);
        else rectTr.sizeDelta = new Vector2(rectTr.rect.width,102);
    }
}
