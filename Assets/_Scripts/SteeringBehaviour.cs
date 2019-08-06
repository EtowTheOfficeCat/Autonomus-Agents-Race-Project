using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    protected Vehicle vehicle;
    public abstract Vector3 Steer();

    public virtual void Awake()
    {
        vehicle = GetComponent<Vehicle>();
    }
}
