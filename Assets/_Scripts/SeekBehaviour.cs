using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : SteeringBehaviour
{
    private Transform target;

    public override void Awake()
    {
        base.Awake();
        target = GameObject.Find("Target").transform;
    }

    public override Vector3 Steer()
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= vehicle.MaxSpeed;
        Vector3 steer = desired - vehicle.Velocity;
        steer = Vector3.ClampMagnitude(steer, vehicle.MaxForce);
        return steer;
    }
}
