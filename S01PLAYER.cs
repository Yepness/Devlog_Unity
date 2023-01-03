using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S01PLAYER : MonoBehaviour
{
    //var primitive:
    //private int numInt = 10;
    //private float numFlt = 10.5f;
    //private string textStr = "Hello World";
    //private bool orTF = true;

    //var transform para controlar o transform do jogador:
    public Transform _transform;
    //var transform para controlar o transform da camera01:
    public Transform camTransform01;

    //var RigidBody do player:
    public Rigidbody rb;
    //var detectar layers:
    public LayerMask Layermask;

    //var valor da força do pulo:
    public float jumpForce = 5.0f;

    //var bool de se estamos no chão:
    public bool grounded;
    //var tamanho da area de chacagem do chão:
    public float groundedSize;
    //var posição da area de checagem do chão:
    public Vector3 groundedPosition;

    //var de 2 vetores (x,y) para rotação do mouse;
    Vector2 mouseRotation;

    //var sensibilidade:
    public float Sense = 1000.0f;

    //var obj do player:
    public GameObject pl1;

    //var de animação:
    private Animator anim;

    //var de fisica:
    private Rigidbody rig;

    //var colisão:
    private Collider col;

    //var velocidade:
    public float vel = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //A variável do rigidbody vai pegar o componente de nome rigidbody de todos os objetos onde este script estiver linkado:
        rig = GetComponent<Rigidbody>();

        //A variável do collider vai pegar o componente de colisão de todos os objetos onde este script estiver linkado:
        col = GetComponent<Collider>();

        //A variável do animator vai pegar o componente de colisão de todos os objetos onde este script estiver linkado:
        anim = GetComponent<Animator>();

        //Travar mouse no centro da tela:
        Cursor.lockState = CursorLockMode.Locked;

        //Esconder mouse da tela:
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    //Movimentação do mouse:
      Vector2 controlMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
      //definindo o valor da rotação sendo 2 vetores multiplicado pela var sensibilidade e por Time.deltaTime referente aos frames por segundo do void update:
      mouseRotation = new Vector2(mouseRotation.x + controlMouse.x * Sense * Time.deltaTime,
                                  mouseRotation.y + controlMouse.y * Sense * Time.deltaTime);

    //Aplicar a rotação da visão do jogador no transform do player mantendo a rotação x e z como estavam:
      _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, mouseRotation.x, _transform.eulerAngles.z);

    //Limitar a visão vertical para a rotação não ultrapassar para trás da cabeça:
      mouseRotation.y = Mathf.Clamp(mouseRotation.y, -80, 80);

    //Aplicar a rotação da visão do jogador na vertical, movimentando agora apenas o transform da camera:
      //(mouseRotation.y com valor negativo para não ficar invertido)
      camTransform01.localEulerAngles = new Vector3(-mouseRotation.y, camTransform01.localEulerAngles.y, camTransform01.localEulerAngles.z);

    //Player:

      //Enquanto W estiver sendo pressionado:
      if(Input.GetKey(KeyCode.W))
      {
        pl1.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * vel);
        //setar o Bool da animação que definimos como Runfoward para true:
        anim.SetBool("Runfoward", true);
      }
      //Quando W parar de ser pressionado (quando a tecla subir):
      if(Input.GetKeyUp(KeyCode.W))
      {
        //setar o Bool da animação que definimos como Runfoward para false:
        anim.SetBool("Runfoward", false);
      }
      //Enquanto S estiver sendo pressionado:
      if(Input.GetKey(KeyCode.S))
      {
        pl1.transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * vel);
        //setar o Bool da animação que definimos como Runback para true:
        anim.SetBool("Runback", true);
      }
      //Quando S parar de ser pressionado (quando a tecla subir):
      if(Input.GetKeyUp(KeyCode.S))
      {
        //setar o Bool da animação que definimos como Runback para false:
        anim.SetBool("Runback", false);
      }
      //Enquanto D estiver sendo pressionado:
      if(Input.GetKey(KeyCode.D))
      {
        pl1.transform.Translate(new Vector3(1,0,0) * Time.deltaTime * vel);
        //setar o Bool da animação que definimos como Runright para true:
        anim.SetBool("Runright", true);
      }
      //Quando D parar de ser pressionado (quando a tecla subir):
      if(Input.GetKeyUp(KeyCode.D))
      {
        //setar o Bool da animação que definimos como Runright para false:
        anim.SetBool("Runright", false);
      }
      //Enquanto A estiver sendo pressionado:
      if(Input.GetKey(KeyCode.A))
      {
        pl1.transform.Translate(new Vector3(-1,0,0) * Time.deltaTime * vel);
        //setar o Bool da animação que definimos como Runleft para true:
        anim.SetBool("Runleft", true);
      }
      //Quando A parar de ser pressionado (quando a tecla subir):
      if(Input.GetKeyUp(KeyCode.A))
      {
        //setar o Bool da animação que definimos como Runleft para false:
        anim.SetBool("Runleft", false);
      }

      //Quando espaço for pressionado:
      if(Input.GetKeyDown(KeyCode.Space))
      {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
      }


      //criamos uma variável temporária que irá criar uma esfera da posição e tamanho que definirmos e listar os objetos dentro da área (posição,tamanho,layermask):
      var groundcheck = Physics.OverlapSphere(transform.position + groundedPosition, groundedSize, Layermask);
      //se a quantidade de objetos checados dentro da área for diferente de zero:
      if(groundcheck.Length != 0)
      {
        //Então o personagem estará no chão (true):
        grounded = true;
      }
      //se não:
      else 
      {
        //O personagem não estará no chão (false):
        grounded = false;
      }  
      //Fazer animação do pulo:
      anim.SetBool("Jump", !grounded);

      //Se a tecla N estiver sendo pressionada desabilitar a gravidade nos objetos em que essa script estiver linkado:  
      if(Input.GetKey(KeyCode.N))
      {
        rig.useGravity = false;
      }
      if(Input.GetKeyUp(KeyCode.N))
      {
        rig.useGravity = true;
      }
      //Se a tecla M estiver sendo pressionada habilitar a opção isTrigger de colisão nos objetos em que essa script estiver linkado: 
      //isTrigger permite atravessar outros objetos. 
      if(Input.GetKey(KeyCode.M))
      {
        col.isTrigger = true;
      }
      if(Input.GetKeyUp(KeyCode.M))
      {
        col.isTrigger = false;
      }
      //Enquanto B estiver sendo pressionado:
      if(Input.GetKey(KeyCode.B))
      {
        //setar o Bool da animação que definimos como Breakdance para true:
        anim.SetBool("Breakdance", true);
      }
      if(Input.GetKeyUp(KeyCode.B))
      {
        //setar o Bool da animação que definimos como Breakdance para false:
        anim.SetBool("Breakdance", false);
      }
    }

    //Função criada para podermos ver a área de verificação do chão:
    private void OnDrawGizmos()
    { 
        //todo Gizmos desenhados serão da cor vermelha:
        Gizmos.color = Color.red;
        //Desenharemos uma esfera pegando nossa posição + checagem de chão e o tamanho referente ao radius da esfera:
        Gizmos.DrawWireSphere(transform.position + groundedPosition, groundedSize);
    }
}
