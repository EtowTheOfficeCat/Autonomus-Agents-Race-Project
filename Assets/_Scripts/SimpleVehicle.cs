using UnityEngine;

public class SimpleVehicle : MonoBehaviour
{
    public Transform Target;
    public float Mass = 1f;
    public Vector3 Velocity;
    public float MaxForce = 1f;
    public float MaxSpeed = 1f;
    public float fleeRange = 10f;

    public void Update()
    {
        //Seek(Target.position);
        Flee(Target.position);
    }

    public void UpdateVehicle(Vector3 force)
    {
        Vector3 acceleration = force / Mass;
        Velocity += acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
    }

    public void Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= MaxSpeed;
        Vector3 steer = desired - Velocity;
        steer = Vector3.ClampMagnitude(steer, MaxForce);
        UpdateVehicle(steer);
    }

    public void Flee(Vector3 target)
    {
        Vector3 desired = transform.position - target;
        if (desired.sqrMagnitude < fleeRange * fleeRange)
        {
            desired.Normalize();
            desired *= MaxSpeed;
            Vector3 steer = desired - Velocity;
            steer = Vector3.ClampMagnitude(steer, MaxForce);
            UpdateVehicle(steer);
        }
        else
        {
            transform.position += MaxSpeed * Velocity.normalized * Time.deltaTime;
        }
    }
}
