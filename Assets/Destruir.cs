using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public GameObject impactEffectPrefab;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        // Instancia el efecto de impacto en el punto de colisión
        GameObject impactEffect = Instantiate(impactEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        // Destruye el efecto de impacto después de un corto periodo
        Destroy(impactEffect, 1f);

        // Destruye el proyectil
        Destroy(gameObject);
    }
}

