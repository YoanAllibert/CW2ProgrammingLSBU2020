using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]//Diverts the selection to this object
public class AntennaScript : MonoBehaviour
{
    [Header("Physics Parameters")]
    [SerializeField] private float springForce = 80.0f;
    [SerializeField] private float drag = 2.5f;
    
    
	[Space(12)]
    public Transform GeoParent;

    Rigidbody SpringRB;
    private Vector3 LocalDistance;//Distance between the two points
    private Vector3 LocalVelocity;//Velocity converted to local space
    public Transform springTarget;
    public Transform springObj;

    void Start()
    {
        SpringRB = springObj.GetComponent<Rigidbody>();//Find the RigidBody component
        springObj.transform.parent = null;//Take the spring out of the hierarchy
    }

    void FixedUpdate()
    {
        //Sync the rotation 
        SpringRB.transform.rotation = this.transform.rotation;

        //Calculate the distance between the two points
        LocalDistance = springTarget.InverseTransformDirection(springTarget.position - springObj.position);
        SpringRB.AddRelativeForce((LocalDistance) * springForce);//Apply Spring

        //Calculate the local velocity of the springObj point
        LocalVelocity = (springObj.InverseTransformDirection(SpringRB.velocity));
        SpringRB.AddRelativeForce((-LocalVelocity) * drag);//Apply drag

        //Aim the visible geo at the spring target
        GeoParent.transform.LookAt(springObj.position);
        GeoParent.transform.Rotate(90f, 0f, 0f);
    }
}
