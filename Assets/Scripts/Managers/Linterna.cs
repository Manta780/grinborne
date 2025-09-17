using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    private Light2D light2D;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.1f;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(Time.time * flickerSpeed, 0f));
    }
}
