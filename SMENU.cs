using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SMENU : MonoBehaviour
{
    //[SerializeField] serve para fazer os campos aparecerem no inspetor:
    //var para definição do menu principal:
    [SerializeField]private GameObject PMENU;
    //var para definição do menu de configurações:
    [SerializeField]private GameObject PSETTINGS;
    
    void Start()
    {   
        //Iniciar apenas com o painel do menu ativo:
        PMENU.SetActive(true);
        PSETTINGS.SetActive(false);
    }

    //Esta função será acionada quando o botão de PLAY for pressionado:
    public void Play()
    {
        SceneManager.LoadScene("DevRoom");
    }

    //Esta função será acionada quando o botão de SETTINGS for pressionado:
    public void Settings()
    {
        //quando abrimos opções desativar o painel do menu principal e abrir o painel de configurações:
        PMENU.SetActive(false);
        PSETTINGS.SetActive(true); 
    }

    //Esta função será acionada quando o botão de DONE dentro de SETTINGS for pressionado:
    public void CloseSettings()
    {
        //quando apertarmos o botão DONE o painel de configurações será desativado e o de menu principal será ativado novamente:
        PMENU.SetActive(true);
        PSETTINGS.SetActive(false);    
    }

    //Esta função será acionada quando o botão de EXIT for pressionado:
    public void EXIT()
    {
        //Fechar o jogo (Funciona apenas com o jogo build):
        Application.Quit();
    }

    //Esta função será acionada quando o botão de PLAY for pressionado:
    public void Sense()
    {
        
    }
}
