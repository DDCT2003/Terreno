using UnityEngine;

public class CameraFreeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody rb;
    private Quaternion originalRotation;
    public Canvas canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        originalRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        // Verificar si alguna tecla de movimiento está presionada
        bool isMoving = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ||
                        Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        // Si alguna tecla de movimiento está presionada, aplicar movimiento hacia adelante
        if (isMoving)
        {
            // Obtener la dirección hacia adelante del tanque (basada en su rotación actual)
            Vector3 moveDirection = transform.forward;

            // Aplicar movimiento hacia adelante en la dirección actual del tanque
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            // Si no se presiona ninguna tecla de movimiento, detener el movimiento
            rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        // Rotar el tanque según la tecla presionada
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
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con una bala
        if (collision.gameObject.name == "Enemigo")
        {
            this.gameObject.SetActive(false);
            canvas.enabled = true;
            Debug.Log("Perdiste");

        }
    }
}
