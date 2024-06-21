using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala

    private Rigidbody rb; // Para 3D
    // private Rigidbody2D rb; // Para 2D

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody2D>(); // Para 2D

        // Aplicar velocidad en la dirección del disparo
        rb.velocity = transform.forward * velocidad;
        // rb.velocity = transform.right * velocidad; // Para 2D, suponiendo que la bala se dispara hacia la derecha
    }
}
