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
        
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / Mass;
    }

    public void UpdateVehicle()
    {
        Velocity += acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
        acceleration = Vector3.zero;
    }

}
