using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField]
    private int vida;

    public void Danio(int danio)
    {
        vida -= danio;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
