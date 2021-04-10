using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private PlayerStats playerStatsInstance;
    private Enemy enemy;

    private Transform target;
    private int waypointIndex = 0;
    private float distanceTravelled;
    private Vector3 lastPosition;
    private float distanceToGoal = 0;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        enemy = GetComponent<Enemy>();

        target = Waypoints.waypoints[0];

        for (int i = 0; i < Waypoints.waypoints.Length - 2; i++)
        {
            distanceToGoal += Vector3.Distance(Waypoints.waypoints[i + 1].position, Waypoints.waypoints[i].position);
        }

        distanceTravelled = 0f;
        lastPosition = transform.position;
    }

    private void Update()
    {
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

    private void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    private void EndPath()
    {
        playerStatsInstance.ReduceLives();
        Destroy(gameObject);
    }

    public float GetDistanceToGoal()
    {
        return distanceToGoal;
    }
}
