using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float Mass = 1f;
    public Vector3 Velocity;
    public float MaxForce = 1f;
    public float MaxSpeed = 1f;
    private Vector3 acceleration;
    public SteeringBehaviour[] steeringBehaviours;

    private void Awake()
    {
        steeringBehaviours = GetComponents<SteeringBehaviour>();
    }

    public void ApplyForce(Vector3 force, float weight)
    {
        //acceleration += (force * weight) / Mass;
        force = (Time.deltaTime / Mass) * force;
        force *= weight;
        acceleration += force;
        acceleration = Vector3.ClampMagnitude(acceleration, MaxForce);
    }

    public void UpdateVehicle()
    {
        Velocity += acceleration;
        Velocity = Vector3.ClampMagnitude(Velocity, MaxSpeed);
        transform.position += Velocity * Time.deltaTime;
        acceleration = Vector3.zero;
    }

}
