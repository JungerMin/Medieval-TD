using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;
    private float distanceTravelled;
    private Vector3 lastPosition;

    public float distanceToGoal = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];

        for (int i = 0; i < Waypoints.waypoints.Length - 2; i++)
        {
            distanceToGoal += Vector3.Distance(Waypoints.waypoints[i + 1].position, Waypoints.waypoints[i].position);
        }

        distanceTravelled = 0f;
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        distanceTravelled = Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        distanceToGoal -= distanceTravelled;
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
