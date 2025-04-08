using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movimiento con:
/// 
/// Transform: Te da libertad en lo que quieras hacer, te limita las detecciones
/// Character Controller: Te da facilidad de movimiento y deteccion, pero te limita las fisicas
/// RigidBody: Te da facilidad para movimiento y deteccion, pero requiere mayor trabajo para lograr precision
/// 
/// </summary>
public class MovementController : MonoBehaviour
{

    [SerializeField] private float crouchSpeed = 4;
    [SerializeField] private float walkspeed = 6;
    [SerializeField] private float runSpeed = 8;

    [SerializeField] private float jumpForce = 5.3f;

    private Rigidbody rb; // Este rigidbody para mas seguridad de obtencion, lo obtenemos unicamente buscando el componente

    private Respawn respawn;


    private void Start()
    {       

        respawn = FindObjectOfType<Respawn>();

        rb = rb == null ? GetComponent<Rigidbody>() : rb;
        bool puedePasar = true; // Indica si se puede o no pasar a un lugar
        bool esMayorDeEdad = false;
        bool tieneIne = false;

        Debug.Log(puedePasar ? "Puede pasar" : "No puede pasar");
        Debug.Log(esMayorDeEdad ? tieneIne? "Puedes pasar" : "No puedes pasar" : "No puedes pasar");

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Debug.Log(HorizontalAxis());
        Debug.Log(Speed());
        Move();
        Jump();
    }

    /// <summary>
    /// La unica funcion de un metodo vacio es realizar instrucciones
    /// Su mision en la vida es seguir instrucciones y ya
    /// </summary>
    private void Move() // void = vacio
    {
        rb.velocity =  transform.rotation * new Vector3(HorizontalAxis(),rb.velocity.y,VerticalAxis()) * Speed(); // (x,y,z) (x,y,z)
    }

    /// <summary>
    /// Su mision es devolvernos cual de las 3 velocidades es la que necesitamos (walk, run, crouch)
    /// </summary>
    /// <returns></returns>
    public float Speed()
    {
        if (RunInputPressed())
        {
            return runSpeed;
        }
        else if (CrouchInputPressed())
        {
            return crouchSpeed;
        }

        return RunInputPressed()? runSpeed : CrouchInputPressed()? crouchSpeed : walkspeed; 
    }

    private void Jump()
    {
        if (JumpInputPressed())
        {
            Debug.Log("Saltando");
            rb.AddForce(Vector3.up*jumpForce);
        }
    }
  
    private float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal"); // -1 , 1 en X
    }

    private float VerticalAxis() 
    {
        return Input.GetAxis("Vertical"); // -1 , 1 en Z
    }

    public bool JumpInputPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool RunInputPressed()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public bool CrouchInputPressed()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }

   

}
