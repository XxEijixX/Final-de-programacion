using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    [SerializeField] private string creditsSceneName = "Credits"; // Nombre de la escena de créditos

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Credits"); // Carga la escena de créditos
        }
    }
}
