using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamageable
{
    public int health;

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Esqueleto dañado. Ahora tiene {health} puntos de vida");
        // animacion de dano
        // sonido de dano

        if( health <= 0)
        {
            Debug.Log("Esqueleto muerto");
        }
    }

}
