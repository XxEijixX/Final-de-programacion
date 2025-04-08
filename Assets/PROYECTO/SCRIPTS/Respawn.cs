using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public string lastCheckpoint; // Aqui guardas cual es el ultimo

    private Transform checkPoint; // Aqui es el checkpoint al que vas a ir
    private Transform player;

    public static Respawn instance; // Para saber que ya existe un repawn en la escena

    private void Awake()
    {
        if (instance == null) // Esta variable ya deberia tener asignado el respawn de la escena anterior
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Respawn destruido");
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void Spawn()
    {
        if (!string.IsNullOrEmpty(lastCheckpoint))
        {
            checkPoint = GameObject.Find(lastCheckpoint).transform;

            player = GameObject.Find("Prueba").transform;

            player.transform.position = checkPoint.position;
        }
    }

}
