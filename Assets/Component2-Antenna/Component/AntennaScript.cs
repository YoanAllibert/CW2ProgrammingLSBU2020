using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class AntennaScript : MonoBehaviour
{
    [Header("Line Parameters")]
    [SerializeField] [Range(0.1f, 10f)] private float length = 1f;
    [SerializeField] private float baseWidth = 0.01f;
    [SerializeField] private Material materialToUse;

    [Header("Physics Parameters")]
    [SerializeField] private float springForce = 80.0f;
    [SerializeField] private float drag = 2.5f;

    private Rigidbody spring_body;
    private Vector3 LocalDistance;
    private Vector3 LocalVelocity;
    private Transform target;
    private Transform spring;

    private LineRenderer lineRenderer;

    void Start()
    {
        FindChildObjects();
        spring_body = spring.GetComponent<Rigidbody>();
        lineRenderer = gameObject.GetComponentInChildren<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        SetUpLine();
        PlaceObjectCorrectLength();
        spring.transform.parent = null;
    }

    void FixedUpdate()
    {
        Vector3 endPoint = (spring_body.position - transform.position).normalized;
        endPoint *= length;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + endPoint);
        
        spring_body.transform.rotation = this.transform.rotation;

        LocalDistance = target.InverseTransformDirection(target.position - spring.position);
        spring_body.AddRelativeForce((LocalDistance) * springForce);

        LocalVelocity = (spring.InverseTransformDirection(spring_body.velocity));
        spring_body.AddRelativeForce((-LocalVelocity) * drag);
    }

    private void FindChildObjects()
    {
        target = this.gameObject.transform.GetChild(1);
        spring = target.GetChild(0);
    }

    private void SetUpLine()
    {
        lineRenderer.gameObject.GetComponent<Renderer>().material = materialToUse;
        lineRenderer.startWidth = baseWidth;
    }

    private void PlaceObjectCorrectLength()
    {
        Vector3 endPoint = (spring_body.position - transform.position).normalized;
        endPoint *= length;
        target.position = transform.position + endPoint;
        spring_body.position = transform.position + endPoint;
    }
}