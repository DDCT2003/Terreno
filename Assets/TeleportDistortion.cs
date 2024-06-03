using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TeleportDistortion : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private LensDistortion lensDistortion;
    public float distortionDuration = 0.5f;
    private float currentTime = 0.0f;
    private bool isTeleporting = false;

    void Start()
    {
        // Intentar obtener la configuración de LensDistortion del perfil de post-procesamiento
        postProcessVolume.profile.TryGetSettings(out lensDistortion);
    }

    void Update()
    {
        if (isTeleporting)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / distortionDuration;
            lensDistortion.intensity.value = Mathf.Lerp(0, 100, t); // Ajusta los valores según tu efecto deseado

            if (currentTime >= distortionDuration)
            {
                isTeleporting = false;
                currentTime = 0.0f;
                lensDistortion.intensity.value = 0;
            }
        }
    }

    public void StartDistortion()
    {
        isTeleporting = true;
    }
}

