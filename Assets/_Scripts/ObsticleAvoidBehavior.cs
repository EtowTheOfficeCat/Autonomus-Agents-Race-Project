using UnityEngine;

public class ObsticleAvoidBehavior : SteeringBehaviour
{
    public Obsticle[] Obsticles;
    public float maxAhead = 5f;
    

    public override Vector3 Steer()
    {
        Vector3 antenna = vehicle.Velocity * maxAhead;
        Obsticle threat = null;
        Vector3 nearesPointToObsticle = Vector3.zero;

        for ( int i = 0; i < Obsticles.Length; i++)
        {
            var o = Obsticles[i];
            var pos = transform.position;
            var toObsticle = o.Position - pos;
            float percOnAntenna = (Vector3.Dot(antenna, toObsticle)) / antenna.sqrMagnitude;
            if(percOnAntenna <0f || percOnAntenna > 1f)
            {
                continue;
            }
            var nearestOnAtenna = pos + antenna * percOnAntenna;
            nearesPointToObsticle = o.Position - nearestOnAtenna;
            var sqrRadius = o.Radius * o.Radius;
            if(sqrRadius > nearesPointToObsticle.sqrMagnitude)
            {
                if(threat == null || toObsticle.sqrMagnitude < (threat.Position - pos).sqrMagnitude)
                {
                    threat = o;
                }
            }
        }
        if (threat != null)
        {
            //var desired = antenna - threat.Position;
            //desired = desired.normalized * vehicle.MaxSpeed;
            //var steer = Vector3.ClampMagnitude (desired - vehicle.Velocity, vehicle.MaxForce) * threat.Radius;
            var desired = -nearesPointToObsticle * (nearesPointToObsticle.magnitude + threat.Radius * 2f);
            var steer = desired - vehicle.Velocity;
            return steer;
        }
        else
            {
            return Vector3.zero;
        }
        
        
    }
} 
