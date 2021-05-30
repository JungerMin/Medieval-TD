using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private PlayerStats playerStatsInstance;
    private Enemy enemy;

    private Transform target;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private float distanceTravelled;
    private Vector3 lastPosition;
    private float distanceToGoal = 0;

    private bool blocked = false;

    public GameObject waypointsObject;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        enemy = GetComponent<Enemy>();

        waypoints = waypointsObject.GetComponent<Waypoints>().waypoints;

        target = waypoints[0];

        for (int i = 0; i < waypoints.Length - 2; i++)
        {
            distanceToGoal += Vector3.Distance(waypoints[i + 1].position, waypoints[i].position);
        }

        distanceTravelled = 0f;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (blocked)
        {
            return;
        }


        if (target != null && !blocked)
        {
            transform.LookAt(target.position);
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemy.currentSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWayPoint();
            }

            distanceTravelled = Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            distanceToGoal -= distanceTravelled;
        }
    }

    private void GetNextWayPoint()
    {
        if (waypointIndex >= waypoints.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = waypoints[waypointIndex];
    }

    private void EndPath()
    {
        playerStatsInstance.ReduceLives();
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    public float GetDistanceToGoal()
    {
        return distanceToGoal;
    }

    public void Blocked()
    {
        blocked = true;
    }

    public void NotBlocked()
    {
        blocked = false;
    }
}
