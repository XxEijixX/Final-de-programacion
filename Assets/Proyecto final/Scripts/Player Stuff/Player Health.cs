using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 150;
    private int currentHealth;

    public TextMeshProUGUI vidaTexto;
    private bool isDead = false;

    public Transform spawnPoint; // Asigna esto en el Inspector
    private PlayerMove movementScript;
    private CharacterController charController;
    private NavMeshAgent navAgent;

    private void Start()
    {
        currentHealth = maxHealth;
        ActualizarUI();

        movementScript = GetComponent<PlayerMove>();
        charController = GetComponent<CharacterController>();
        navAgent = GetComponent<NavMeshAgent>();

        if (spawnPoint == null)
        {
            Debug.LogWarning("No hay spawnPoint asignado. Usando posición inicial del jugador.");
            spawnPoint = new GameObject("DefaultSpawnPoint").transform;
            spawnPoint.position = transform.position;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        ActualizarUI();

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void ActualizarUI()
    {
        if (vidaTexto != null)
            vidaTexto.text = "Vida: " + currentHealth;
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Jugador muerto. Respawneando...");

        // 1. Desactivar movimiento y controles
        movementScript.enabled = false;

        // 2. Desactivar NavMeshAgent (si existe)
        if (navAgent != null)
        {
            navAgent.enabled = false;
        }

        // 3. Desactivar CharacterController (para evitar bloqueos)
        if (charController != null)
        {
            charController.enabled = false;
        }

        // 4. Iniciar respawn después de un delay
        Invoke("Respawn", 2f);
    }

    void Respawn()
    {
        Debug.Log("Respawneando en: " + spawnPoint.position);

        // 1. Mover el jugador al spawn (sin físicas)
        transform.position = spawnPoint.position;

        // 2. Reactivar componentes
        if (charController != null)
        {
            charController.enabled = true;
        }

        if (navAgent != null)
        {
            navAgent.enabled = true;
            navAgent.Warp(spawnPoint.position); // Forzar posición en NavMesh
        }

        movementScript.enabled = true;

        // 3. Restaurar salud
        currentHealth = maxHealth;
        ActualizarUI();
        isDead = false;
    }
}
