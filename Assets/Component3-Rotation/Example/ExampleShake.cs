using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleShake : MonoBehaviour
{
    [SerializeField] private CameraShake shakeScript;

    public void CallShakeOnButtonClick(int index)
    {
        switch (index)
        {
            case 1:
                Shake1();
                break;
            case 2:
                Shake2();
                break;
            case 3:
                Shake3();
                break;
            case 4:
                Shake4();
                break;
            default:
                Shake1();
                break;
        }
    }

    private void Shake1()
    {
        shakeScript.Shake(4f, 0.4f, 1.1f, false);
    }
    private void Shake2()
    {
        shakeScript.Shake(9f, 0.3f, 0.5f,  false);
    }
    private void Shake3()
    {
        shakeScript.Shake(3f, 0.5f, 2.5f, true);
    }
    private void Shake4()
    {
        shakeScript.Shake(15f, 0.2f, 0.4f, true);
    }
}