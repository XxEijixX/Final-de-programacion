using UnityEngine;

/// <summary>
/// CLASS / CLASES
/// El nombre de el script/clase es el nombre de tu problema a resolver y no de donde va a ir el script
/// Nomenclatura: Pascal Case
/// 
/// VARIABLES
/// El nombre de las variables es el nombre de exactamente el dato que contienen y/o sus caracteristicas
/// Nomenclatura: Camel Case
/// 
/// METODOS
/// Son el como resuelves tu problema. Los pasos o acciones necesarias para resolverlo
/// El nombre de los metodos es el nombre de la accion que van a hacer
/// Nomenclatura: Pascal Case
/// 
/// ORGANIZAR EL CODIGO YA SEA EN PARTES O POR FUNCIONES
/// 
/// 
/// Time.timeScale es el tiempo que usa unity, si este esta en 0, todo lo que este en el tiempo de unity se congela
/// 
/// time.unscaledTime es el tiempo que pasa en la vida real, independietemente de el tiempo de unity
/// </summary>
public class Apuntes : MonoBehaviour
{
    /// <summary>
    /// PROTECCION DE VARIABLES
    /// 
    /// public se puede acceder a esa variable desde cualquier lado, y modificarla. Se puede ver desde el inspector
    /// 
    /// private no se puede acceder a esa variable desde ningun otro lado que no sea el script donde se declaro. No se ve en el inspector
    /// 
    /// internal es un nivel de proteccion, el cual solo permite acceder a sus variables, metodos, etc... siempre y cuando se encuentren en el mismo
    /// espacio de trabajo. Es decir, es publica dentro de el namespace, es privada fuera de este a no ser que se este usando la libreria.
    /// 
    /// protected es publico dentro de la herencia, privado para cualquier otro lado
    /// 
    /// { get; private set; } te permite leer la variable desde otros scripts, pero no te permite modificarla fuera de donde se declaro
    /// 
    /// [SerializeField] te crea un campo en el inspector, y el valor de el campo se le pasa a la variable, no modifica su privacidad. Lo usamos unicamente cuando estamos haciendo pruebas, una vez que
    /// el valor de la variable ya esta definido, quitamos el serialize field
    /// </summary>

    [SerializeField] private int numero = 25; // Esta es mi variable original, esta la puedo modificar en el inspector y en este script, pero en otro script no puedo
    public int _Numero
    { // Esta variable sirve como punto de acceso a mi variable original "numero", de manera que ya tengo una variable que es privada, la cual puedo ver en 
        get => numero; // el inspector, pero si quisiera leer su valor desde otro lado, gracias a este acceso tambien puedo

        private set
        {

        }
    }

    bool booleano;

    public float numeroDecimal = 5.5f;
    public string nombre { get; private set; }
    public int vida { get; private set; } // 100 

    public float time;



    public void Metodo()
    {
        UnityEngine.Random.Range(0, Time.deltaTime);
        numero = 34;
        _Numero = 34;

        System.Random rnd = new System.Random();
    }

    public void BajarVida(int vidaABajar) // 50
    {
        vida -= vidaABajar; // 100 - 50 = 50
    }

    public void SetName(string name)
    {
        nombre = name;
    }


    /// <summary>
    /// El metodo Awake es el primer metodo que se ejecuta de el script al aparecer en la escena, ya sea si el objeto esta activo o no
    /// 
    /// En este metodo tu debes de conseguir informacion, objetos y/o referencias de alta importancia para el funcionamiento de el script
    /// </summary>
    private void Awake()
    {
        Debug.Log("Despertando");
        // consigo los stats 
    }

    /// <summary>
    /// El metodo Start se ejecuta al activarse el script por primera vez
    /// 
    /// En este metodo es donde haria configuraciones iniciales para el funcionamiento de el script
    /// </summary>
    private void Start()
    {
        Debug.Log("Iniciando");
    }

    public bool tiempoEscalado;

    /// <summary>
    /// El update ejecuta lo que esta dentro cada frame
    /// Ciclos en el update no
    /// 
    /// GetKey te funciona mientras tengas presionada la tecla
    /// GetKeyDown es de una presion
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 5;
        }

        if (tiempoEscalado)
            transform.position += new Vector3(0, 0, Time.deltaTime);
        else
            transform.position += new Vector3(0, 0, Time.unscaledDeltaTime);
    }

    /// <summary>
    /// Sucede una cantidad predeterminada de veces por segundo
    /// 
    /// Aqui pondrias las funciones vitales/criticas de el juego, que si se interrumpen por bajones de frame, quieres que sigan funcionando
    /// 
    /// Fisicas
    /// </summary>
    private void FixedUpdate()
    {

    }


    /// <summary>
    /// Este metodo se ejecuta cada vez que el componente u objeto se activa
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("Activacion: " + numero);
        numero++;
    }

    /// <summary>
    /// Este metodo se ejecuta cada vez que el componente u objeto se desactiva
    /// </summary>
    int numero2 = 0;
    private void OnDisable()
    {
        Debug.Log("Desactivacion: " + numero2);
        numero2++;
    }


    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;

    /// <summary>
    /// Es un metodo que se ejecuta cada vez que le realizas un cambio al inspector
    /// </summary>
    private void OnValidate()
    {



    }


}


//public class MovementController : MonoBehaviour
//{

//    public float walkSpeed;
//    public float runSpeed;
//    public float crouchSpeed;

//    public float jumpSpeed;
//    public float jumpAcceleration;
//    public float jumpHeight;

//    public Vector3 dashDirection;
//    public float dashSpeed;
//    public float dashDistance;
//    public bool dashOnCooldown;


//    public void Inputs()
//    {

//    }

//    public void WalkMovement()
//    {
//        walkSpeed = 4;
//    }

//    public void RunMovement()
//    {
//        runSpeed = 6;
//    }

//    public void CrouchMovement()
//    {
//        crouchSpeed = 2;
//    }

//    public void Jump()
//    {

//    }

//    public void Dash()
//    {

//    }

//}

