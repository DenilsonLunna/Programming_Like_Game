using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAcoes : MonoBehaviour {

    [SerializeField] private GameObject programaBlocos;
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject programaDesenho;
    [SerializeField] private GameObject Web;

    public void voltarParaMenu(){
        programaBlocos.SetActive(false);
        menuPrincipal.SetActive(true);
        programaDesenho.SetActive(false);
        Web.SetActive(false);
    }
    public void abrirProgramaBlocos(){
        programaBlocos.SetActive(true);
        menuPrincipal.SetActive(false);
        programaDesenho.SetActive(false);
        Web.SetActive(false);
    }
    public void abrirProgramaDesenho(){
        programaBlocos.SetActive(false);
        menuPrincipal.SetActive(false);
        programaDesenho.SetActive(true);
        Web.SetActive(false);
    }
    public void abrirProgramaWeb(){
        programaBlocos.SetActive(false);
        menuPrincipal.SetActive(false);
        programaDesenho.SetActive(false);
        Web.SetActive(true);
    }
}
