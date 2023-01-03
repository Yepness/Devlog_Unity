using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S05_MANAGEMENT : MonoBehaviour
{
    //var para definir velocidade da rotação em float:
    private float _rotationSpeed = 2f;
    //var para definir o material do skybox utilizado a ser rotacionado:
    public Material _skybox;

    void Start()
    {
        _skybox = Instantiate(RenderSettings.skybox);
        RenderSettings.skybox = _skybox;
    }

    void Update()
    {
        RotateSkybox(Time.timeSinceLevelLoad * _rotationSpeed);
    }

    private void RotateSkybox(float angle)
    {
        _skybox.SetFloat("_Rotation", angle);
    }
}
