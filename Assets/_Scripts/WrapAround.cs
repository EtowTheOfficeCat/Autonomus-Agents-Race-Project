using UnityEngine;

public class WrapAround : MonoBehaviour
{
    private Camera cam;
    private Renderer rend;

    private void Awake()
    {
        cam = Camera.main;
        rend = GetComponentInChildren<Renderer>();
    }
    void Update()
    {
        //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        //if (!GeometryUtility.TestPlanesAABB(planes, rend.bounds))
        Vector3 oldVPP = cam.WorldToViewportPoint(transform.position);
        if (oldVPP.x < 0f || oldVPP.x > 1f || oldVPP.y < 0f || oldVPP.y > 1f)
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Vector3 newVPP = Vector3.one;
            if (oldVPP.x < 0f)
            {
                newVPP = new Vector3(1f, oldVPP.y, oldVPP.z);
            }
            else if (oldVPP.x > 1f)
            {
                newVPP = new Vector3(0f, oldVPP.y, oldVPP.z);
            }
            if (oldVPP.y < 0f)
            {
                newVPP = new Vector3(oldVPP.x, 1f, oldVPP.z);
            }
            else if (oldVPP.y > 1f)
            {
                newVPP = new Vector3(oldVPP.x, 0f, oldVPP.z);
            }
            Ray ray = cam.ViewportPointToRay(newVPP);
            if (plane.Raycast(ray, out float distance))
            {
                transform.position = ray.origin + ray.direction * distance;
            }
        }
    }
}
