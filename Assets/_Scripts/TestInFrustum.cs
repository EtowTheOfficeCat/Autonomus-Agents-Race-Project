using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInFrustum : MonoBehaviour
{
    private Camera cam;
    private Renderer rend;
    private bool isOutOfBounds;

    private void Awake()
    {
        cam = Camera.main;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, rend.bounds))
        {
            isOutOfBounds = false;
        }
        else
        {
            isOutOfBounds = true;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label($"Target is out of bounds: {isOutOfBounds}");
    }
}
