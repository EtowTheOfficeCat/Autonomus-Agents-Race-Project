using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public Vehicle[] vehicles;

    void Update()
    {
        for (int v = 0; v < vehicles.Length; v++)
        {
            Vehicle vehicle = vehicles[v];
            SteeringBehaviour[] steeringBehaviours = vehicle.steeringBehaviours;
            for (int sb = 0; sb < steeringBehaviours.Length; sb++)
            {
                Vector3 steer = steeringBehaviours[sb].Steer();
                vehicle.ApplyForce(steer);
                vehicle.UpdateVehicle();
            }
        }
    }
}
