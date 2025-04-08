using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IDamageable
{
    public int durabilidad;

    public void GetDamage(int damage)
    {
        durabilidad -= damage;
        ObtenerRecursos();
        // sonido de dano
        // depende el dano cambia el modelo
        if(durabilidad <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void ObtenerRecursos()
    {
        int random = Random.Range(1, 5);
        Debug.Log($"Obtuviste {random} rocas y se añadieron a tu inventario");
    }

}
