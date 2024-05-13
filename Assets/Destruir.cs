using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si la bala ha colisionado con un objeto que no sea ella misma
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }
    }
}

