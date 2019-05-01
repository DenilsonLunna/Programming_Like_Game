using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizePanelDuplo : MonoBehaviour {


    [Header("Recebe o Painel1, o primeiro painel")]
    [SerializeField]
    private RectTransform rectTransformPanel;
    [Header("Recebe o Painel2, o segundo painel")]
    [SerializeField]
    private RectTransform rectTransformPanel2;//recebe o painel 2
    [Header("Recebe a primeira barra lateral, Nome da barra(Base1)")]
    [SerializeField]
    private RectTransform rectTransformImgBarra;//recebe a imagem da barra lateral, esse sera mudado a sua altura conforme o "rectTransformPanel"
    [Header("Recebe a segunda barra lateral, Nome da barra(Base2)")]
    [SerializeField]
    private RectTransform rectTransformImgBarra2;
    [Header("Recebe toda a estrutura do bloco, o Bloco principal")]
    [SerializeField]
    private LayoutElement bloco;//o bloco ou laço, ele recebera o tamanhanho dele mais o tamanho de seu painel.
    [SerializeField] private int tamanhoBloco;// tamanho do bloco duplo sem intruçoes

    [SerializeField]
    private float larguraBarra, larguraBarra2, alturaBarra, alturaBarra2,alt1,alt2;
  
    // Update is called once per frame
    void Update()
    {
        //larguraBarra = 22.5f;//largura da imagem "barra"
        //larguraBarra2 = 1f;//largura da imagem "barra"
        alturaBarra = rectTransformPanel.rect.height; //altura da imagem "barra1"
        alturaBarra2 = rectTransformPanel2.rect.height; //altura da imagem "barra2"
        if(alturaBarra2 < 30) alturaBarra2 = 30;
        rectTransformImgBarra.sizeDelta = new Vector2(larguraBarra, alturaBarra+alt1); // modifica altura e largura da barra
        rectTransformImgBarra2.sizeDelta = new Vector2(larguraBarra2, alturaBarra2+alt2); // modifica altura e largura da barra2

        bloco.preferredHeight = rectTransformPanel2.rect.height + rectTransformPanel.rect.height + tamanhoBloco; //modifica o tamanho do bloco

    }
}
