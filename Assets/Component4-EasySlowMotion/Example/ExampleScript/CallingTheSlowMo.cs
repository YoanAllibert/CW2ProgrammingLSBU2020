using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallingTheSlowMo : MonoBehaviour
{
    [SerializeField] [Range(0.05f, 0.99f)] private float scale = 0.5f;
    [SerializeField] [Range(0f, 4f)] private float fadeIn = 0.5f;
    [SerializeField] [Range(0f, 10f)] private float duration = 2f;
    [SerializeField] [Range(0f, 4f)] private float fadeOut = 0.5f;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EasySlowMotion.StartSlowMo(scale, fadeIn, duration, fadeOut);
        }
    }
}
