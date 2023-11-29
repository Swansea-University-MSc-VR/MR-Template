using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class NavMeshBaker : MonoBehaviour
{
    public float updateInterval;
    private float timeSinceLastUpdate = 0.0f;
    private ARPlane[] _ARPlanes;
    public TextMeshProUGUI text;


    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastUpdate > updateInterval)
        {
            timeSinceLastUpdate = 0.0f;
            LookForARPlane();
            Debug.Log("Update");
        }
        else
        {
            timeSinceLastUpdate += Time.deltaTime;
        }

        //Debug.Log(timeSinceLastUpdate);
    }

    private void LookForARPlane()
    {
        _ARPlanes = FindObjectsOfType<ARPlane>();

        if(_ARPlanes.Length > 0)
        {
            NavMeshSurface surface = _ARPlanes[0].GetComponent<NavMeshSurface>();
            surface.BuildNavMesh();
            text.text = "ARPlane found " +  _ARPlanes.Length;
        }
        else
        {
            text.text = "No ARPlane found";
        }
    }
    
}




