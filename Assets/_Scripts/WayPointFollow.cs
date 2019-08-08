using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : SteeringBehaviour
{
    public Transform[] WayPoints;
    public float arrivalThreshold = 0.5f;
    public Transform CurTarget;
    int curIdx = 0;

    
    public override Vector3 Steer()
    {
        Vector3 desired = CurTarget.position - transform.position;
        if(desired.sqrMagnitude < arrivalThreshold * arrivalThreshold)
        {
            curIdx = (curIdx + 1) % WayPoints.Length;
            CurTarget = WayPoints[curIdx];
        }
        desired.Normalize();
        desired *= vehicle.MaxSpeed;
        Vector3 steer = desired - vehicle.Velocity;
        steer = Vector3.ClampMagnitude(steer, vehicle.MaxForce);
        return steer;
    }
}
