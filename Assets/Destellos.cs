using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destellos : MonoBehaviour
{
    public GameObject muzzleFlashPrefab;
    public Transform gunBarrel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil en la posici�n y rotaci�n del punto de disparo
        // Instancia el Muzzle Flash en la posici�n del ca��n del arma
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, gunBarrel.position, gunBarrel.rotation);
        // Destruye el Muzzle Flash despu�s de un corto periodo
        Destroy(muzzleFlash, 0.1f);
    }
}
