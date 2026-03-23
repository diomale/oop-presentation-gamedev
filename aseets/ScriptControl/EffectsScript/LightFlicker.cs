using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour
{
    [Header("Lights to Flicker")]
    [SerializeField] private List<Light2D> lights = new List<Light2D>();

    [Header("Flicker Timing")]
    [SerializeField] private float minTime = 0.05f;
    [SerializeField] private float maxTime = 0.2f;

    private void Start()
    {
        StartCoroutine(FlickerLights());
    }

    IEnumerator FlickerLights()
    {
        while (true)
        {
            foreach (Light2D light in lights)
            {
                if (light != null)
                {
                    light.enabled = !light.enabled;
                }
            }

            float wait = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(wait);
        }
    }
}