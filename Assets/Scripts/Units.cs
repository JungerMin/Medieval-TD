using UnityEngine;

public class Units : MonoBehaviour
{
    protected GameObject target;
    protected Enemy targetEnemy;

    [Header("Unit Stats")]

    public float range = 2f;
    public float attackSpeed = 1f;
    protected float fireCountdown = 0f;
    public float rotationSpeed = 10f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public string debuffName;
    public GameObject debuff;
    public Transform partToRotate;
    protected Animator animator;
    protected void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        animator = GetComponent<Animator>();
        debuff.name = debuffName;
    }

    protected void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack"))
        {
            animator.speed = attackSpeed;
            animator.Play("Base Layer.Attack", 0, 0f);
        }
    }

    protected void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float distanceToTarget = Mathf.Infinity;
        float shortestPath = Mathf.Infinity;

        if (target != null)
        {
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget > range)
            {
                target = null;
            }
        }

        foreach (GameObject enemy in enemies)
        {
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            float pathEnemy = enemyMovement.GetDistanceToGoal();
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range && pathEnemy < shortestPath)
            {
                distanceToTarget = distanceToEnemy;
                shortestPath = pathEnemy;
                target = enemy;
                targetEnemy = enemy.GetComponent<Enemy>();
            }
        }
    }

    protected void LockOnTarget()
    {
        Vector3 dir = target.transform.position - transform.position; // find Vector from Turret to enemy
        Quaternion lookRotation = Quaternion.LookRotation(dir); // find Rotation needed to allign to dir
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles; // get eulerAngles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // set rotation of turret
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
