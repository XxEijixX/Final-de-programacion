using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseEstatica : MonoBehaviour
{

    public static int numero = 10;

    public static ClaseEstatica Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Debug.Log(Instance.gameObject.name);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void MetodoEstatico(string palabra)
    {
        Debug.Log(palabra);
    }



}
