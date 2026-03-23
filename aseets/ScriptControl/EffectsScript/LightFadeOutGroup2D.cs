using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class LightFadeOutGroup2D : MonoBehaviour
{
    [Header("Lights to Fade")]
    [SerializeField] private List<Light2D> lights = new List<Light2D>();

    [Header("Fade Settings")]
    [SerializeField] private float fadeSpeed = 1f;

    void Update()
    {
        foreach (Light2D light in lights)
        {
            if (light == null) continue;

            light.intensity = Mathf.MoveTowards(
                light.intensity,
                0f,
                fadeSpeed * Time.deltaTime
            );

            if (light.intensity <= 0.01f)
            {
                light.enabled = false;
            }
        }
    }
}