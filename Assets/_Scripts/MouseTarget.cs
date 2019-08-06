using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    private Camera cam;
    private Plane plane;

    void Awake()
    {
        cam = Camera.main;
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 pointAlongPlane = ray.origin + ray.direction * distance;
            transform.position = new Vector3(pointAlongPlane.x, 0f, pointAlongPlane.z);
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }
}
