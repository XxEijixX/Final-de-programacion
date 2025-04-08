using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int damage = 10;  // Da�o que la bala causar� al enemigo
    public float pushBackForce = 5f;  // Fuerza de empuje al enemigo

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Verifica si colisiona con un enemigo
        {
            Enemy enemy = other.GetComponent<Enemy>(); // Obtiene el componente Enemy del enemigo

            if (enemy != null)
            {
                // Le aplica el da�o al enemigo
                enemy.TakeDamage(damage);

                // Aplica el empuje al enemigo
                Vector3 direction = other.transform.position - transform.position; // Direcci�n opuesta a la bala
                direction.y = 0; // Aseguramos que no se mueva hacia arriba o abajo

                // Aplica el empuje utilizando la direcci�n calculada
                enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity = direction.normalized * pushBackForce;
            }

            Destroy(gameObject); // Destruye la bala al colisionar
        }
    }
}
