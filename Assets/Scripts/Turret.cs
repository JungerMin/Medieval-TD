using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject targetEnemy = null;
        float distanceToTarget = Mathf.Infinity;
        float shortestPath = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            EnemyAI enemy1 = enemy.GetComponent<EnemyAI>();
            float pathEnemy = enemy1.distanceToGoal;
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range && pathEnemy < shortestPath)
            {
                distanceToTarget = distanceToEnemy;
                shortestPath = pathEnemy;
                targetEnemy = enemy;
            }
        }

        if (targetEnemy != null && distanceToTarget <= range)
        {
            target = targetEnemy.transform;
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // target lookon
        Vector3 dir = target.position - transform.position; // find Vector from Turret to enemy
        Quaternion lookRotation = Quaternion.LookRotation(dir); // find Rotation needed to allign to dir
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles; // get eulerAngles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // set rotation of turret
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}
