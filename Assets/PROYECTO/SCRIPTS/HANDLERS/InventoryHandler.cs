using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Este script lo unico de lo que se va a encargar es de la gestion de los items
/// de el inventario. Añadir y remover. 
/// 
/// 
/// EJERCICIO VA A SER:
/// 
/// 
/// 1RO.- Al añadir un objeto el inventario, el objeto recogido debe de desactivarse en la escena
/// 2DO.- Presionando la letra G un objeto de tu inventario debe de aparecer en tu posicion, y eliminarse de la lista(inventario).
/// Es como soltar algo del inventario y debe de poder volverse a agarrar
/// </summary>
public class InventoryHandler : MonoBehaviour
{

    [SerializeField] public List<Item> inventario; // Esta lista es mi inventario y aqui se guardan game objects
    public List<Item> _Inventario { get => inventario;} // Esta variable me permite leer el inventario desde
    // otros scripts, pero no modificarlo

    public int indice;

    public int maxCapacity = 24;

    public int numero;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TirarObjeto();
        }
    }

    public void AgregarObjeto(Item item)
    {
        inventario.Add(item);        
    }

    public void TirarObjeto()
    {
        Instantiate(inventario[indice]._prefab, transform.position,transform.rotation);
        inventario.RemoveAt(indice);
    }



}
