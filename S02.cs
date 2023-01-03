using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Biblioteca de gerenciamento de cenas da unit:
using UnityEngine.SceneManagement;

public class S02 : MonoBehaviour
{
    //var de próxima cena:
    public string NextScene;

    //void para verificar se estou colidindo passando o argumento (Collider) de colisão:
    void OnTriggerEnter(Collider col)
    {
        //Se houver o trigger de colisão definido no void acima com o objeto do jogo que tiver a tag "Player":
        if(col.gameObject.tag=="Player") 
        {
           //Destruir o objeto que o script está linkado:
           Destroy(gameObject); 
           //Utilizar o gerenciamento de cena da biblioteca importada e carregar a cena referente a nossa var de próxima cena:
           //Poderiamos usar também o nome direto da cena (SceneManager.LoadScene("InGame"))
           SceneManager.LoadScene(NextScene);
        } 
    }    
}
