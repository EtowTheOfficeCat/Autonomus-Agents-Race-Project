using UnityEngine;

public class ArriveBehaviour : SteeringBehaviour
{
    public float DecelerationTweaker = 30f;
    public float SlowDownDistance;
    private float slowDownStartSpeed;
    private Transform target;
    private float t;
    private bool isStartSpeedSet;

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
            if (!isStartSpeedSet)
            {
                slowDownStartSpeed = vehicle.Velocity.magnitude;
                isStartSpeedSet = true;
            }
            t = distanceToTarget / SlowDownDistance;
            float mappedSpeed = Mathf.Lerp(0f, slowDownStartSpeed, t);
            mappedSpeed = mappedSpeed < 0.2f ? 0f : mappedSpeed;
            desired = desired.normalized * mappedSpeed;
            steer = desired - vehicle.Velocity;
            float decel = (1 - t * t * t) * DecelerationTweaker;
            steer *= decel;
        }
        else
        {
            isStartSpeedSet = false;
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
