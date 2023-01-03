using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S00 : MonoBehaviour
{
    //var primitive:
    //private int numInt = 10;
    //private float numFlt = 10.5f;
    //private string textStr = "Hello World";
    //private bool orTF = true;

    //var obj das caixas 1,2:
    public GameObject box1;
    public GameObject box2;

    //var de fisica:
    private Rigidbody rig;

    //var colisão:
    private Collider col;

    //var velocidade:
    public float vel = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //A variável do rigidbody vai pegar o componente de nome rigidbody de todos os objetos onde este script estiver linkado:
        rig = GetComponent<Rigidbody>();

        //A variável do collider vai pegar o componente de colisão de todos os objetos onde este script estiver linkado:
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
      //Box:  
      //Se a tecla I estiver sendo pressionada o translate do transform receberá 3 novos vetores (x,y,z) vezes Time.deltaTime (serve para igualar os frames do jogo) vezes a variavél da velocidade:  
      if(Input.GetKey(KeyCode.I))
      {
        box1.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * vel);
      }
      if(Input.GetKey(KeyCode.O))
      {
        box1.transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * vel);
      }

      //Se a tecla A estiver sendo pressionada rotacionar o objeto nos eixos (x,y,z) no próprio eixo (Space.Self):  
      if(Input.GetKey(KeyCode.H))
      {
        box1.transform.Rotate(0,10,0, Space.Self);
      }
      if(Input.GetKey(KeyCode.J))
      {
        box1.transform.Rotate(0,-10,0, Space.Self);
      }

      //Se a tecla R houver sido pressionada desativar objeto caixa 1 da cena e ativar objeto caixa 2:
      if(Input.GetKeyDown(KeyCode.R))
      {
        box1.SetActive(false);
        box2.SetActive(true);
      }

      //Se a tecla T houver sido pressionada desativar objeto caixa 2 da cena e ativar objeto caixa 1:
      if(Input.GetKeyDown(KeyCode.T))
      {
        box1.SetActive(true);
        box2.SetActive(false);
      }

      //Se a tecla Y estiver sendo pressionada desabilitar a gravidade nos objetos em que essa script estiver linkado:  
      if(Input.GetKey(KeyCode.Y))
      {
        rig.useGravity = false;
      }

      //Se a tecla U estiver sendo pressionada habilitar a opção isTrigger de colisão nos objetos em que essa script estiver linkado: 
      //isTrigger permite atravessar outros objetos. 
      if(Input.GetKey(KeyCode.U))
      {
        col.isTrigger = true;
      }
    }
}
