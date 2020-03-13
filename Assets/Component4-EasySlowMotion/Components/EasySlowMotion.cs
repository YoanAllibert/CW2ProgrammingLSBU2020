using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySlowMotion : MonoBehaviour
{
    private static float currentTimeScale = 1f;
    private static bool isSlowMo = false;

    private static float _scale;
    private static float _fadeIn;
    private static float _duration;
    private static float _fadeOut;

    private static float timer = 0f;

    private void Update()
    {
        if (isSlowMo)
            PlaySlowMotion();
    }

    private void PlaySlowMotion()
    {
        if (timer < _fadeIn) //We are fading In
        {
            float step = timer / _fadeIn;
            currentTimeScale = Mathf.Lerp(1f, _scale, step);
        }
        else if(timer < _fadeIn + _duration) //We are in SlowMo
        {
            currentTimeScale = _scale;
        }
        else if(timer > (_fadeIn + _duration + _fadeOut)) //We finished SlowMo
        {
            currentTimeScale = 1f;
            isSlowMo = false;
        }
        else //We are fading Out
        {
            float currentPositionFadeOut = timer - _duration - _fadeIn;
            float step = currentPositionFadeOut / _fadeIn;
            currentTimeScale = Mathf.Lerp(_scale, 1f, step);
        }

        timer += Time.unscaledDeltaTime;
        Time.timeScale = currentTimeScale;
    }

    public static void StartSlowMo(float scale, float fadeIn, float duration, float fadeOut)
    {
        if (isSlowMo)
            return;

        _scale = scale;
        _fadeIn = fadeIn;
        _duration = duration;
        _fadeOut = fadeOut;
        timer = 0f;

        isSlowMo = true;
    }
}