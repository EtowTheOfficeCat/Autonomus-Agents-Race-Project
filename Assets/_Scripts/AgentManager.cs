using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public Vehicle[] vehicles;

    private void Start()
    {
        foreach (Vehicle vehicle in vehicles)
        {
            SeparationBehaviour sb = vehicle.GetComponent<SeparationBehaviour>();
            if(sb != null)
            {
                sb.vehicles = this.vehicles;
            }
        }
    }

    void Update()
    {
        for (int v = 0; v < vehicles.Length; v++)
        {
            Vehicle vehicle = vehicles[v];
            SteeringBehaviour[] steeringBehaviours = vehicle.steeringBehaviours;
            for (int sbIdx = 0; sbIdx < steeringBehaviours.Length; sbIdx++)
            {
                var sb = steeringBehaviours[sbIdx];
                Vector3 steer = sb.Steer();
                vehicle.ApplyForce(steer, sb.data.Weight);
                vehicle.UpdateVehicle();
            }
        }
    }
}
