using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraSeguir : MonoBehaviour
{


    public Transform objetivo; // El objeto que la cámara va a seguir
    public float velocidadSuave = 0.125f; // Velocidad de seguimiento suave
    public Vector3 offset; // Desplazamiento de la cámara con respecto al objetivo

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // LateUpdate se llama después de Update
    void LateUpdate()
    {
        // Calcular la posición deseada de la cámara solo en los ejes X y Z
        Vector3 posicionDeseada = objetivo.position + offset;

        // Mantener la posición actual en el eje Y (altitud) de la cámara
        posicionDeseada.y = transform.position.y;

        // Mover la cámara suavemente hacia la posición deseada utilizando Lerp
        Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuave);

        // Actualizar la posición de la cámara
        transform.position = posicionSuave;
    }

}

