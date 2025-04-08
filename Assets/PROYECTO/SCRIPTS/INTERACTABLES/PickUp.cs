using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{

    public Item item;

    private InventoryHandler inventory;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryHandler>();
    }

    public void Interact()
    {
        inventory.AgregarObjeto(item);
        Debug.Log(item.name + " Añadida al inventario");
        Debug.Log("Descripcion: " + item._description);
        Destroy(gameObject);
    }


}
