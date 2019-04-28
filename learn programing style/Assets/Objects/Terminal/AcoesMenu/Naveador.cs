using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naveador : MonoBehaviour {

    [SerializeField] private GameObject pagDicas;
    [SerializeField] private GameObject pagInicial;
    [SerializeField] private GameObject pagEquipe;
    [SerializeField] private Text tituloNavegador;


    public void abrirPaginaDicas(){
        pagDicas.SetActive(true);
        pagInicial.SetActive(false);
        pagEquipe.SetActive(false);
        tituloNavegador.text = "https://www.joogle.com/dicas";
    }

    public void abrirPaginaViuTube(){
        pagEquipe.SetActive(true);
        pagDicas.SetActive(false);
        pagInicial.SetActive(false);
        tituloNavegador.text = "https://www.joogle.com/equipe";
    }

    public void voltar(){
        pagEquipe.SetActive(false);
        pagDicas.SetActive(false);
        pagInicial.SetActive(true);
        tituloNavegador.text = "https://www.joogle.com/";
    }
}
