using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;
    public float distanceToGoal = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];

        for (int i = 0; i < Waypoints.waypoints.Length - 2; i++)
        {
            distanceToGoal += Vector3.Distance(Waypoints.waypoints[i + 1].position, Waypoints.waypoints[i].position);
        }
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        distanceToGoal -= Vector3.Distance(Waypoints.waypoints[waypointIndex + 1].position, Waypoints.waypoints[waypointIndex].position);
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
