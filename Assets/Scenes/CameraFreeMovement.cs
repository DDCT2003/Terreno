using UnityEngine;

public class CameraFreeMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float mouseSensibility;

    float xRotation;
    float yRotation;

    void Start()
    {
        // Locks the mouse to the center of the Game view.
        Cursor.lockState = CursorLockMode.Locked;
        // Mouse not visible
        Cursor.visible = false;
    }

    void Update()
    {
        Rotate();
        Move();
    }
    public void Rotate()
    {
        //Get mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensibility * Time.deltaTime;

        //Remember the ballerina
        xRotation -= mouseY;
        yRotation += mouseX;

        //Pa que no se desnuque
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotar
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
    public void Move()
    {
        //Get move Input
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //Calculate direction
        Vector3 moveDirection = transform.forward * vInput + transform.right * hInput;

        //Mover
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
