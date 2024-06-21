using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBala : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde donde se disparará la bala
    public float intervaloDeDisparo = 5f; // Intervalo de disparo en segundos

    private void Start()
    {
        StartCoroutine(DispararCadaIntervalo());
    }

    private IEnumerator DispararCadaIntervalo()
    {
        while (true)
        {
            Disparar();
            yield return new WaitForSeconds(intervaloDeDisparo);
        }
    }

    private void Disparar()
    {
        // Instanciar la bala en el punto de disparo del enemigo
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Si quieres ajustar la dirección de la bala, puedes hacerlo aquí
        // Por ejemplo, si la bala debería seguir la dirección en la que el enemigo está mirando:
        // bala.transform.forward = transform.forward;
    }
}
