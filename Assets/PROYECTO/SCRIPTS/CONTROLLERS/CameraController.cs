using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity; // Sensibilidad
    [SerializeField] private float smoothness; // Suavidad

    private float maxAngleY = 80;
    private float minAngleY = -80;

    private Vector2 camVelocity; // Cam velocity es donde se va a guardar e indicar como se movera la camara
    private Vector2 smoothVelocity; // smooth velocity es donde se guardara la formula para suavizar la camara  

    private Transform player;

    private void Start()
    {

        //player = GetComponentInParent<Transform>();

        if(transform.parent != null)
        {
            if (transform.parent.TryGetComponent<Transform>(out player))
            {
                Debug.Log("Se encontro el player");
            }
            else
            {
                Debug.LogWarning("No se encontro al player");
            }
        }
        else
        {
            Debug.LogWarning("La camara no esta emparentada");
        }
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        
     
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {       
        Vector2 rawMouseVelocity = Vector2.Scale(MousePos(), Vector2.one * mouseSensitivity); //1.- Conseguir Input y multiplicarlo por la sensibilidad
        smoothVelocity = Vector2.Lerp(smoothVelocity, rawMouseVelocity,1 / smoothness); // 2.- Que tan suave se va a mover  
        camVelocity += smoothVelocity; // 0,0   5,5 + 0,0 =  5,5 + 2,3 = 7,8 // Sumando vectores, que van desde donde esta el mouse hacia el nuevo punto a donde se movio
        camVelocity.y = Mathf.Clamp(camVelocity.y,minAngleY,maxAngleY); // Te limita el movimiento de el mouse en Y, para que no gire la cabeza hacia atras como el exorcista

        transform.localRotation = Quaternion.AngleAxis(-camVelocity.y, Vector3.right);
        player.localRotation = Quaternion.AngleAxis(camVelocity.x, Vector3.up);
    }

    private Vector2 MousePos()
    {
        return new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // 2,3    4,6  6,9
    }

}
