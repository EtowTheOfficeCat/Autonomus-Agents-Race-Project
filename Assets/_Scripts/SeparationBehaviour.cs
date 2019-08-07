using UnityEngine;

public class SeparationBehaviour : SteeringBehaviour
{
    public float separationDistance;
    public Vehicle[] vehicles;

    public override Vector3 Steer()
    {
        Vector3 avgDir = Vector3.zero;
        int numberOfCloseVehicles = 0;
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == vehicle)
            {
                continue;
            }
            Vector3 dir = vehicles[i].transform.position - transform.position;
            float sqrDistance = dir.sqrMagnitude;
            if (sqrDistance<separationDistance*separationDistance)
            {
                avgDir += dir.normalized;
                numberOfCloseVehicles++;
            }
        }
        if (numberOfCloseVehicles==0)
        {
            return Vector3.zero;
        }
        avgDir /= numberOfCloseVehicles;
        avgDir = new Vector3(avgDir.x, 0f, avgDir.z);
        Vector3 desired = avgDir * (-1) * vehicle.MaxSpeed;
        Vector3 steer = desired - vehicle.Velocity;
        steer = Vector3.ClampMagnitude(steer, vehicle.MaxForce);

        return steer;
    }
}
