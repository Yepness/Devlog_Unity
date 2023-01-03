using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S04_CAM : MonoBehaviour
{

    //var camera:
    public GameObject camObj01;
    public GameObject camObj02;


    //Definir os 2 audio listener:
    AudioListener camAudio01;
    AudioListener camAudio02;

    // Start is called before the first frame update
    void Start()
    {
        //Pegar os componentes Audio Listeners das cameras em separado:
        camAudio01 = camObj01.GetComponent<AudioListener>();
        camAudio02 = camObj02.GetComponent<AudioListener>();

        //Iniciar apenas na camera 02:
        camObj01.SetActive(true);
        camAudio01.enabled = true;

        camObj02.SetActive(false);
        camAudio02.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       //Se o botão LeftAlt for pressionado chamar o void de mudança da camera:
      if(Input.GetKey(KeyCode.LeftAlt))
      {
        camObj01.SetActive(true);
        camAudio01.enabled = true;

        camObj02.SetActive(false);
        camAudio02.enabled = false;
      }

      if(Input.GetKey(KeyCode.RightAlt))
      {
        camObj01.SetActive(false);
        camAudio01.enabled = false;

        camObj02.SetActive(true);
        camAudio02.enabled = true;
      } 
    }
}
