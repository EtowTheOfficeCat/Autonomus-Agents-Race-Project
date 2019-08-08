using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public Vehicle[] vehicles;
    public Obsticle[] Obsticles;
    public Transform[] WayPoints;

    private void Start()
    {
        foreach (Vehicle vehicle in vehicles)
        {
            SeparationBehaviour sb = vehicle.GetComponent<SeparationBehaviour>();
            if(sb != null)
            {
                sb.vehicles = this.vehicles;
            }
            ObsticleAvoidBehavior oab = vehicle.GetComponent<ObsticleAvoidBehavior>();
            if (oab!= null)
            {
                oab.Obsticles = Obsticles;
            }
            WayPointFollow wpf = vehicle.GetComponent<WayPointFollow>();
            if(wpf != null)
            {
                wpf.WayPoints = WayPoints;
                wpf.CurTarget = WayPoints[0];
            }
        }
    }

    void Update()
    {
        for (int v = 0; v < vehicles.Length; v++)
        {
            Vehicle vehicle = vehicles[v];
            if (!vehicle.isActiveAndEnabled)
            {
                continue;
            }
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
