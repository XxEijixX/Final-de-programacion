using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")] // Esta linea añade un boton al menu de creacion de assets. El boton se llama Item, 
// y cuando das click crea un scriptable object de nombre New Item
public class Item : ScriptableObject
{
    public string _name;
    public string _description;
    public GameObject _prefab;
    public Sprite _sprite;
}
