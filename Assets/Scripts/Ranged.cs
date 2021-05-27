using UnityEngine;

public class Ranged : Units
{
    [Header("Projectile Stats")]
    public int damage = 20;
    public float projectileSpeed = 20f;
    public float explosionRadius = 0f;

    [Header("Projectile Setup Fields")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    private void Update()
    {
        if (target == null)
        {
            animator.Play("Base Layer.Idle");
            return;
        }

        LockOnTarget();
        Attack();
    }

    private void Shoot()
    {
        GameObject projectileGameObject = (GameObject) Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGameObject.GetComponent<Projectile>();

        SetProjectile(projectile);

        if (projectile != null && target != null)
        {
            projectile.Seek(target.transform);
        }
    }

    private void SetProjectile(Projectile _projectile)
    {
        _projectile.SetDamage(damage);
        _projectile.SetProjectileSpeed(projectileSpeed);
        _projectile.SetExplosionRadius(explosionRadius);
        _projectile.SetDebuff(debuff);
    }
}
