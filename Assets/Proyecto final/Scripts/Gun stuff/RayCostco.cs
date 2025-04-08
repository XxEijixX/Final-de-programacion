using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayCostco : MonoBehaviour
{
    [SerializeField] private int danio;
    [SerializeField] private float force;
    [SerializeField] private float velocidadBala;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject bala;
    [SerializeField] private int maxBalas = 10;
    [SerializeField] private TextMeshProUGUI balasTexto; // Referencia al UI de balas

    private Transform puntoDisparo;
    private Transform aim;
    private RaycastHit hit;
    private float machineCont = 0;
    private Transform agarrado;
    private int balasActuales;

    private void Start()
    {
        puntoDisparo = transform.parent;
        aim = transform.GetChild(0);
        balasActuales = maxBalas; // Comienza con 10 balas
        ActualizarUI();
    }

    void Update()
    {
        // Disparo con clic izquierdo
        if (Input.GetMouseButtonDown(0) && machineCont <= 0 && balasActuales > 0)
        {
            Disparar();
            balasActuales--; // Resta una bala
            ActualizarUI();
            machineCont = 0.2f;
        }

        // Disparo de bala con clic derecho
        if (Input.GetMouseButtonDown(1) && balasActuales > 0)
        {
            DispararBala();
            balasActuales--;
            ActualizarUI();
        }

        machineCont -= Time.deltaTime;
    }

    private void Disparar()
    {
        if (Physics.Raycast(puntoDisparo.position, transform.forward, out hit, 100))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<VidaEnemigo>().Danio(danio);
                GameObject objetito = Instantiate(obj, hit.point, obj.transform.rotation);
                Destroy(objetito, 5);
                objetito.transform.SetParent(hit.transform);
            }

            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }

    private void DispararBala()
    {
        GameObject cosa = Instantiate(bala, aim.position, bala.transform.rotation);
        cosa.GetComponent<Rigidbody>().AddForce(transform.forward * velocidadBala);
    }

    // Método para recargar balas
    public void Recargar(int cantidad)
    {
        // Agrega las balas, pero no exceda el límite máximo
        balasActuales += cantidad;
        ActualizarUI(); // Actualiza el UI
    }

    // Método para actualizar el UI
    private void ActualizarUI()
    {
        if (balasTexto != null)
        {
            balasTexto.text = "Balas: " + balasActuales.ToString(); // Actualiza el texto del UI
        }
    }
}

