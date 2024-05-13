using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con una bala
        if (collision.gameObject.name == "Bala(Clone)")
        {
            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}
