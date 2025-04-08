using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{

    private ClaseNoEstatica clase;

    private void Start()
    {
        ClaseEstatica.MetodoEstatico(ClaseEstatica.numero.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Respawn.instance.lastCheckpoint = other.gameObject.name;
        }
    }
}
