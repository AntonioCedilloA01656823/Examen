using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Codigo para control de camaras
/// </summary>
public class CameraControl : MonoBehaviour
{
    //Se usa la main camera
    Camera m_MainCamera;

    //camara de cutscene
    public Camera m_CameraCutscene;


    void Start()
        
    {
        //En consola por si se necesita ver
        Debug.Log("Press R to switch to the main camera");
        Debug.Log("Press T for the cutscene camera");

        //Solamente se activa la camara main
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;

        m_CameraCutscene.enabled = false;
    }

    void Update()
    {
        // Boton T para cambiar a cutscene
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchCamera(m_CameraCutscene);
        }
        // Boton R para regresar a main
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchCamera(m_MainCamera);
        }
    }

    void SwitchCamera(Camera newCamera)
    {
        // Disable all cameras
        m_MainCamera.enabled = false;
        m_CameraCutscene.enabled = false;

        // Enable the selected camera
        newCamera.enabled = true;
    }
}
