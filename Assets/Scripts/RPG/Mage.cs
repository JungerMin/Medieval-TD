using UnityEngine;

public class Mage : Units
{
    [Header("Mage Specific")]
    public Animator animator;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        animator = GetComponent<Animator>();
        debuff.name = "Slow";
    }

    private void Update()
    {
        if (target == null)
        {
            animator.Play("Base Layer.Idle_MagicWand");
            return;
        }

        LockOnTarget();
        Projectile();
    }

    private void Projectile()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01_MagicWand"))
        {
            animator.speed = fireRate;
            animator.Play("Base Layer.Attack01_MagicWand", 0, 0f);
        }
    }

    private void Shoot()
    {
        GameObject magicGameObject = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile magic = magicGameObject.GetComponent<Projectile>();

        SetMagic(magic);

        if (magic != null && target != null)
        {
            magic.Seek(target.transform);
        }
    }

    private void SetMagic(Projectile _magic)
    {
        _magic.SetDamage(damage);
        _magic.SetProjectileSpeed(projectileSpeed);
        _magic.SetExplosionRadius(explosionRadius);
        _magic.SetDebuff(debuff);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
