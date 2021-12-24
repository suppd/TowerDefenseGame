using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public Transform waypointHolder;
    public float speed;

    private int wayPointIndex;
    
    void Start()
    {
        Vector3[] waypoints = new Vector3[waypointHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointHolder.GetChild(i).position;
            //waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));
    }

    void Update()
    {
        
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);
     
        while (true)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
          
            Vector3 oldnewPositionDiffrence = targetWaypoint - transform.position;
            //Debug.Log(oldnewPositionDiffrence.magnitude);
            if (oldnewPositionDiffrence.magnitude < 0.5f)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                if (targetWaypointIndex >= waypoints.Length - 1)
                {
                    Destroy(gameObject);
                    Debug.Log("Destroy");
                }
                //yield return new WaitForSeconds(waitTime);
                //yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            
            yield return null;
        }
       
    }
}
