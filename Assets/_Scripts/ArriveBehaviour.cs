using UnityEngine;

public class ArriveBehaviour : SteeringBehaviour
{
    public float SlowDownDistance;
    private Transform target;
    private float t;

    public override void Awake()
    {
        base.Awake();
        target = GameObject.Find("Target").transform;
    }

    public override Vector3 Steer()
    {
        Vector3 desired = target.position - transform.position;
        Vector3 steer = Vector3.zero;
        float distanceToTarget = desired.magnitude;
        if (distanceToTarget < SlowDownDistance)
        {
            t = distanceToTarget / SlowDownDistance;
            //desired = desired.normalized * t * vehicle.MaxSpeed;
            float mappedSpeed = Mathf.Lerp(0f, vehicle.MaxSpeed, t);
            desired = desired.normalized * mappedSpeed;
            //steer *= SlowDownDistance - distanceToTarget;
            steer = desired - vehicle.Velocity;
            steer = Vector3.ClampMagnitude(steer, vehicle.MaxForce);
        }
        else
        {
            desired = desired.normalized * vehicle.MaxSpeed;
            steer = desired - vehicle.Velocity;
            steer = Vector3.ClampMagnitude(steer, vehicle.MaxForce);
        }
        //Debug.DrawRay(transform.position, steer, Color.red);
        return steer;
    }

    private void OnGUI()
    {
        GUILayout.Label(t.ToString());
    }
}
