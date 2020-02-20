using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightBlink : MonoBehaviour
{
    public enum FlickerType {None, Sinusoidal, ZeroAndBackAgain, Random, RandomPerlinNoise, FromGraph};
    [SerializeField] private FlickerType type;

    [Header("Flickering Parameters")]
    [SerializeField] [Range(0.0f, 20.0f)] private float frequency = 1f;
    [SerializeField] [Range(0.0f, 20.0f)] private float amplitude = 1f;

    [Header("Graph Parameters")]
    [SerializeField] private AnimationCurve graph;

    private Light light;
    private float currentIntensity;

    private float baseIntensity;
    private float passedTime;

    void Start()
    {
        light = GetComponent<Light>();
        currentIntensity = light.intensity;
        baseIntensity = currentIntensity;
    }

    void Update()
    {
        passedTime += Time.deltaTime * frequency;
        light.intensity = baseIntensity + Flicker(type);
    }

    private float Flicker(FlickerType type)
    {
        switch (type)
        {
            case FlickerType.None:
                return 0f;
            
            case FlickerType.Sinusoidal:
                return (Mathf.Sin(passedTime) / 2) * amplitude;  //Goes from  -0.5 to 0.5 with passing time

            case FlickerType.ZeroAndBackAgain:
                //Increase amplitude to mach baseIntensity, then move sin wave lower than 0
                return ((baseIntensity / 2) * Mathf.Sin(passedTime)) - (baseIntensity / 2);

            case FlickerType.Random:
                return Random.Range(-0.1f, 0.1f) * amplitude;

            case FlickerType.RandomPerlinNoise:
                return (Mathf.PerlinNoise(passedTime, 0.0f) - 0.5f) * amplitude;

            case FlickerType.FromGraph:
                if(passedTime >= 1f)
                    passedTime = 0f;
                return graph.Evaluate(passedTime) * amplitude;
            
            default:
                return 0f;
        }
    }
}