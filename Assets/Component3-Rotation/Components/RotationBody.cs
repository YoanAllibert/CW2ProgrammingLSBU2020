using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBody : MonoBehaviour
{
    [SerializeField] private bool clockwise;

    private Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
