using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraSeguir : MonoBehaviour
{


    public Transform objetivo; // El objeto que la c�mara va a seguir
    public float velocidadSuave = 0.125f; // Velocidad de seguimiento suave
    public Vector3 offset; // Desplazamiento de la c�mara con respecto al objetivo

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // LateUpdate se llama despu�s de Update
    void LateUpdate()
    {
        // Calcular la posici�n deseada de la c�mara solo en los ejes X y Z
        Vector3 posicionDeseada = objetivo.position + offset;

        // Mantener la posici�n actual en el eje Y (altitud) de la c�mara
        posicionDeseada.y = transform.position.y;

        // Mover la c�mara suavemente hacia la posici�n deseada utilizando Lerp
        Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuave);

        // Actualizar la posici�n de la c�mara
        transform.position = posicionSuave;
    }

}

