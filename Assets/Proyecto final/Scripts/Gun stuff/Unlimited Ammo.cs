using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlimitedAmmo : MonoBehaviour
{
    [SerializeField] private int danio;
    [SerializeField] private float force;
    [SerializeField] private float velocidadBala;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject bala;
    [SerializeField] private TextMeshProUGUI balasTexto; // Referencia al UI de balas

    private Transform puntoDisparo;
    private Transform aim;
    private RaycastHit hit;
    private float machineCont = 0;
    private Transform agarrado;

    private void Start()
    {
        puntoDisparo = transform.parent;
        aim = transform.GetChild(0);
        ActualizarUI();
    }

    void Update()
    {
        // Disparo con clic izquierdo
        if (Input.GetMouseButtonDown(0) && machineCont <= 0)
        {
            Disparar();
            machineCont = 0.2f;
        }

        // Disparo de bala con clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            DispararBala();
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

    // Método para recargar balas (no se necesita en este caso)

    // Método para actualizar el UI
    private void ActualizarUI()
    {
        if (balasTexto != null)
        {
            balasTexto.text = "Balas: ∞"; // Actualiza el texto del UI mostrando balas infinitas
        }
    }
}
