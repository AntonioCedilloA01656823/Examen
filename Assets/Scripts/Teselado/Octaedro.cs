using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 31/08/24
/// Codigo que crea una esfera y octaedro, mediante un mesh que poseriormente es teselado 
/// para agregarle mas triangulos y formarlo como una esfera. 
/// </summary>
public class Octaedro : MonoBehaviour
{
    /// <summary>
    /// Variables usadas para crear el mesh (renderer y filtro)
    /// y una lista de vectores para los triangulos y una lista de enteros para el orden de dichos triangulos 
    /// </summary>
    MeshFilter mf;
    MeshRenderer mr;
    List<Vector3> geometry;
    List<int> topology;

    /// <summary>
    /// Vectores usados para crear el mesh base, para posteriormente ser teselados. 
    /// </summary>
    Vector3 A, B, C, D, E, F;

    /// <summary>
    /// Material a usarse para la esfera (mas especificamente el color)
    /// </summary>
    public Material material;

    /// <summary>
    /// Función de teselado o subdivisión, que regresa una lista con nueva geometria 
    /// agregadas dependiendo de la lista de 
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    List<int> Subdivide(List<int> triangle)
    {
        //3 = (0+1)/2
        //4 = (0+2)/2
        //5 = (1+2)/2


        int iA = triangle[0];
        int iB = triangle[1];
        int iC = triangle[2];

        int iD, iE, iF;

        Vector3 A = geometry[iA];
        Vector3 B = geometry[iB];
        Vector3 C = geometry[iC];

        //normalizar "para inflar" -> paso 2
        Vector3 D = ((A + B) / 2).normalized;
        Vector3 E = ((B + C) / 2).normalized;
        Vector3 F = ((A + C) / 2).normalized;

        //encontrar si existe

        if (geometry.Contains(D)) iD = geometry.IndexOf(D);
        else
        {
            //agregar si no existe
            iD = geometry.Count;
            geometry.Add(D);
        }


        if (geometry.Contains(E)) iE = geometry.IndexOf(E);
        else
        {
            //agregar si no existe
            iE = geometry.Count;
            geometry.Add(E);
        }


        if (geometry.Contains(F)) iF = geometry.IndexOf(F);
        else
        {
            //agregar si no existe
            iF = geometry.Count;
            geometry.Add(F);
        }
        //cada trio es un triangulo distinto

        List<int> result = new List<int>() { iA, iD, iF, iD, iB, iE, iF, iE, iC, iD, iE, iF, };

        return result;

    }

    // Start is called before the first frame update

    /// <summary>
    /// Función start: Creación de los vectores, geometria y topología.
    /// Uso de la función de subdivisión para crear nueva geometria y topología y remplazarla por la antigua. 
    /// Despues de esto, se hace uso de los renderer para crear la esfera. 
    /// </summary>
    void Start()
    {
        A = new Vector3(0, 0, 1);
        B = new Vector3(1, 0, 0);
        C = new Vector3(0, 1, 0);
        D = new Vector3(0, 0, -1);
        E = new Vector3(-1, 0, 0);
        F = new Vector3(0, -1, 0);


        geometry = new List<Vector3>() { A, B, C, D, E, F };

        //A = 0
        // B = 1
        // C = 2
        // D = 3
        // E = 4
        // F = 5
        topology = new List<int>() {
        //TOP
        0,1,2,
        1,3,2,
        3,4,2,
        4,0,2,


        //BOTTOM
        5,1,0,
        5,3,1,
        5,4,3,
        5,0,4,

        };

        //Funcion de teselado (8 triangulos a 32 triangulos) 
        //para subdivision y extrusion
        int limit = topology.Count;
        for (int i = 0; i < limit; i += 3)
        {
            List<int> division = Subdivide(new List<int>() { topology[i], topology[i + 1], topology[i + 2] });
            foreach (int j in division) topology.Add(j);
        }
        topology.RemoveRange(0, limit); //para quitar los triangulos originales

        limit = topology.Count;
        for (int i = 0; i < limit; i += 3)
        {
            List<int> division = Subdivide(new List<int>() { topology[i], topology[i + 1], topology[i + 2] });
            foreach (int j in division) topology.Add(j);
        }
        topology.RemoveRange(0, limit); //para quitar los triangulos originales





        mf = gameObject.AddComponent<MeshFilter>();
        Mesh miMesh = new Mesh();
        miMesh.vertices = geometry.ToArray();
        miMesh.triangles = topology.ToArray();
        miMesh.RecalculateNormals();
        miMesh.RecalculateBounds();
        mf.sharedMesh = miMesh;
        mr = gameObject.AddComponent<MeshRenderer>();
        mr.material = material;



    }

    // Update is called once per frame
    void Update()
    {

    }
}