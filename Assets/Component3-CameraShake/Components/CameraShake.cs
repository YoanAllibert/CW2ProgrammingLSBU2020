using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeSpeed = 1f;
    private float shakeAmplitude = 1f;
    private bool shakeForwardAxis = false;

    private Vector3 offset = Vector3.zero;
    private float passedTime = 0f;
    private float timer = 0f;
    private float currentDuration = 1f;
    private AnimationCurve easeInOutCurve = new AnimationCurve();

    private bool shaking = false;

    void Start() 
    {
        easeInOutCurve.AddKey(0f, 0f);
        easeInOutCurve.AddKey(0.08f, 1f);
        easeInOutCurve.AddKey(0.92f, 1f);
        easeInOutCurve.AddKey(1f, 0f);
    }

    void Update()
    {
        passedTime += Time.deltaTime * shakeSpeed;
        timer += Time.deltaTime;
    }

    void LateUpdate()
    {
        if (shaking)
        {
            CalculateNoise();
            ApplyOffset();
        }
    }

    private void CalculateNoise()
    {
        float z;
        if (shakeForwardAxis)
            z =  Mathf.PerlinNoise(passedTime, 4f);
        else
            z = 0f;

        offset = new Vector3(Mathf.PerlinNoise(passedTime, 0.0f), Mathf.PerlinNoise(passedTime, 2f), z);
        offset -= new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void ApplyOffset()
    {
        transform.localPosition = offset * shakeAmplitude * easeInOutCurve.Evaluate(timer / currentDuration);
    }

    public void Shake(float speed, float amplitude, float duration, bool useZAxis)
    {
        if (shaking)
            return;
        
        timer = 0f;
        shaking = true;
        shakeForwardAxis = useZAxis ? true : false;
        shakeSpeed = speed;
        shakeAmplitude = amplitude;
        currentDuration = duration;
        StartCoroutine(WaitTimer(duration));
    }

    private IEnumerator WaitTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        shaking = false;
    }
}