using UnityEngine;
using System.Collections;
public class CameraFreeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody rb;
    private Quaternion originalRotation;
    public Canvas canvas;
 
    public GameObject muzzleFlashPrefab;   // Prefab del Muzzle Flash
    public GameObject teleportParticlesPrefab; // Prefab de las part�culas de teletransporte
    public Transform gunBarrel;            // Posici�n del ca��n del arma
    public float cooldownTime = 2f;        // Tiempo de enfriamiento entre teletransportes
    public float teleportDelay = 1f;       // Tiempo de retraso antes del teletransporte
    private float lastTeleportTime;
    private bool canmove;
    private TeleportDistortion teleportDistortion;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        originalRotation = transform.rotation;
        teleportDistortion = GetComponent<TeleportDistortion>();
    }

    void FixedUpdate()
    {
        // Verificar si alguna tecla de movimiento est� presionada
        bool isMoving = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ||
                        Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        if (canmove)
        {

            // Si alguna tecla de movimiento est� presionada, aplicar movimiento hacia adelante
            if (isMoving)
            {
                // Obtener la direcci�n hacia adelante del tanque (basada en su rotaci�n actual)
                Vector3 moveDirection = transform.forward;

                // Aplicar movimiento hacia adelante en la direcci�n actual del tanque
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                // Si no se presiona ninguna tecla de movimiento, detener el movimiento
                rb.velocity = Vector3.zero;
            }
        }
    }
    

    void Update()
    {
        // Rotar el tanque seg�n la tecla presionada
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            // Rotar hacia arriba (0 grados)
            transform.rotation = originalRotation;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            // Rotar hacia la derecha (90 grados)
            transform.rotation = originalRotation * Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            // Rotar hacia la izquierda (-90 grados)
            transform.rotation = originalRotation * Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            // Rotar hacia abajo (180 grados)
            transform.rotation = originalRotation * Quaternion.Euler(0f, 180f, 0f);
        }

        // Verificar si se puede teletransportar (pas� el tiempo de enfriamiento)
        if (Time.time - lastTeleportTime >= cooldownTime && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TeleportRoutine());
        }

    }
    IEnumerator TeleportRoutine()
    {
        rb.velocity = Vector3.zero;
        this.canmove=false;
        teleportDistortion.StartDistortion();

        // Instancia el Muzzle Flash en la posici�n del ca��n del arma
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, gunBarrel.position, gunBarrel.rotation);
        // Destruye el Muzzle Flash despu�s de un corto periodo
        Destroy(muzzleFlash, 0.5f);

        // Obtener la posici�n del mouse en coordenadas de pantalla
        Vector3 mousePosition = Input.mousePosition;
        // Convertir las coordenadas del mouse a coordenadas del mundo
        mousePosition.z = 10; // Establecer una profundidad arbitraria
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Mantener la coordenada Y actual del personaje
        float currentY = transform.position.y;
        Vector3 destination = new Vector3(worldPosition.x, currentY, worldPosition.z);

        // Instanciar part�culas en la posici�n de destino
        GameObject teleportParticles = Instantiate(teleportParticlesPrefab, destination, gunBarrel.rotation);

        // Esperar el tiempo de retraso antes del teletransporte
        yield return new WaitForSeconds(teleportDelay);

        // Mover el personaje a la posici�n del mouse, manteniendo la coordenada Y
        transform.position = destination;

        // Destruir las part�culas despu�s de un corto periodo
        Destroy(teleportParticles, 2f);

        // Actualizar el tiempo del �ltimo teletransporte
        lastTeleportTime = Time.time;
        this.canmove = true;

    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n es con una bala
        if (collision.gameObject.name == "Enemigo")
        {
            this.gameObject.SetActive(false);
            canvas.enabled = true;
            Debug.Log("Perdiste");

        }
    }
}
