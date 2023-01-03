using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03 : MonoBehaviour
{   
    //Var para mencionar nosso player
    public GameObject Player;

    //Void para quando entrar na área colisão:
    private void OnTriggerEnter(Collider col)
    {
        //Se o objeto que estiver colidindo for o player:
        if(col.gameObject == Player)
        {
            //Fazer o transform do Player ser parte do Player do nosso Objeto com o script linkado:
            //(Quando a plataforma se mover o player também vai se mover)
            Player.transform.parent = transform;
        }
    }

    //Void para quando sair da área de colisão:
    private void OnTriggerExit(Collider col)
    {
        //Se o objeto que estiver colidindo for o player:
        if(col.gameObject == Player)
        {
            //Fazer o transform do Player retornar ao valor original dele e deixar de ser parente do nosso objeto:
            Player.transform.parent = null;
        }
    }
}
