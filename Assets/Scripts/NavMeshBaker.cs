using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public float updateInterval;
    private float timeSinceLastUpdate = 0.0f;
    public TextMeshProUGUI text;
    public ARPlaneManager ARPlaneManager;
    public NavMeshAgent agent;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastUpdate > updateInterval)
        {
            timeSinceLastUpdate = 0.0f;
            LookForARPlane();
            Debug.Log("Update");
        }
        else
        {
            timeSinceLastUpdate += Time.deltaTime;
        }
    }

    private void LookForARPlane()
    {

        foreach (var plane in ARPlaneManager.trackables)
        {
            if (plane.transform.position.y < player.position.y)
            {
                plane.GetComponent<NavMeshSurface>().BuildNavMesh();
            }

            if(agent.enabled == false)
            {
                agent.enabled = true;
            }
        }

        if (ARPlaneManager.trackables.count > 0)
        {
            // text.text = "ARPlane found " + ARPlaneManager.trackables.count;

            string s = "";

            foreach (var plane in ARPlaneManager.trackables)
            {
                s += " " + plane.transform.position.y;
            }

            text.text = s + " " + player.position.y;
        }
        else
        {
            text.text = "No ARPlane found";
        }
    }

}




