using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{

    [SerializeField] private TMP_Text vidaTxt;

    [SerializeField] private Image[] corazones; // 5 corazones

    int maxHealth = 5;

    public int health { get => health; 
        private set 
        { 
            health -= value; // Aqui se le resta el danio
            
            for(int i = 0; i < maxHealth; i++) // 3
            {
                if (i > health) // 3
                {
                    corazones[i].gameObject.SetActive(false);
                }
                else
                {
                    corazones[i].gameObject.SetActive(true);
                }
            }
        } 
    }

    public Apuntes apuntes;

    public void GetDamage(int damage)
    {
        apuntes.Metodo();
        apuntes.time = 8;
        Debug.Log(apuntes._Numero);
       
        Debug.Log(apuntes.nombre + " recibio daño");


        health = damage; // se guarda en una variable que se llama value

        apuntes.BajarVida(health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

}
