using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private int balasAAgregar = 5; // Cantidad de balas que se agregarán al jugador

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Accede al script del jugador (RayCostco) y recarga balas
            other.transform.GetChild(0).GetChild(0).GetComponent<RayCostco>().Recargar(balasAAgregar);

            // Destruye el objeto recolector de balas
            Destroy(gameObject);
        }
    }
}
