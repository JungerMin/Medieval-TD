using UnityEngine;

public class Archer : Units
{
    [Header("Archer specific")]
    public Animator animator;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        animator = GetComponent<Animator>();
        debuff.name = "None";
    }

    private void Update()
    {
        if (target == null)
        {
            animator.Play("Base Layer.Idle_Bow");
            return;
        }

        LockOnTarget();
        Projectile();
    }

    private void Projectile()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack01_Bow"))
        {
            animator.speed = fireRate;
            animator.Play("Base Layer.Attack01_Bow",0,0f);
        }
    }

    private void Shoot()
    {
        GameObject arrowGameObject = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile arrow = arrowGameObject.GetComponent<Projectile>();

        SetArrow(arrow);

        if (arrow != null && target != null)
        {
            arrow.Seek(target.transform);
        }
    }

    private void SetArrow(Projectile _arrow)
    {
        _arrow.SetDamage(damage);
        _arrow.SetProjectileSpeed(projectileSpeed);
        _arrow.SetExplosionRadius(explosionRadius);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
