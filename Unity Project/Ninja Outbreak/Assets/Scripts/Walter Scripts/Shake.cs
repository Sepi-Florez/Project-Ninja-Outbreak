using UnityEngine;

public class Shake : MonoBehaviour
{
    [Range(0, 100)]
    public float amplitude = 1;
    [Range(0.00001f, 0.99999f)]
    public float frequency = 0.98f;

    [Range(1, 4)]
    public int iterations = 2;

    [Range(0.00001f, 5)]
    public float persistance = 0.2f;
    [Range(0.00001f, 100)]
    public float lacunarity = 20;

    [Range(0.00001f, 0.99999f)]
    public float burstFrequency = 0.5f;

    [Range(0, 5)]
    public int burstContrast = 2;

    void Update()
    {
        transform.localPosition = NoiseGen.Shake2D(amplitude, frequency, iterations, persistance, lacunarity, burstFrequency, burstContrast, Time.time);
    }
}