using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Codigo usado para rotar un Game object. En este caso, es aplicado para la esfera teselada.
/// </summary>
public class Giro : MonoBehaviour
{
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rota el objeto por script
     objeto.transform.Rotate(Vector3.up * 5f * Time.deltaTime);
    }
}
