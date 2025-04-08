using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movSpeed = 5f;
    [SerializeField] private CharacterController charCtrl;

    [Header("Jump")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private NavMeshAgent navAgent;

    void Start()
    {
        if (charCtrl == null)
            charCtrl = GetComponent<CharacterController>();

        navAgent = GetComponent<NavMeshAgent>();
        if (navAgent != null)
        {
            navAgent.updatePosition = false;
            navAgent.updateRotation = false;
        }
    }

    void Update()
    {
        // Mejor detección de suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resetear velocidad vertical cuando está en el suelo
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Pequeña fuerza hacia abajo para asegurar que está en el suelo
        }

        // Manejo del NavMeshAgent
        if (navAgent != null)
        {
            navAgent.enabled = isGrounded;
        }

        // Movimiento horizontal
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        charCtrl.Move(move * movSpeed * Time.deltaTime);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Gravedad
        velocity.y += gravity * Time.deltaTime;
        charCtrl.Move(velocity * Time.deltaTime);
    }

    // Dibuja el gizmo para ver el radio de detección de suelo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
