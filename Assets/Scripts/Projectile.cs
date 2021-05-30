using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;

    [Header("Stats")]
    private float speed;
    private float explosionRadius;
    private int damage;
    private GameObject debuff;

    [Header("Effects")]
    public GameObject impactEffect;
    public GameObject slowDebuff;

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
        transform.LookAt(target.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in hitObjects)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.gameObject);
            }
        }
    }

    private void ApplyDebuff(Enemy enemy, GameObject debuff)
    {
        if (enemy != null && debuff == slowDebuff)
        {
            enemy.DebuffSlow(debuff);
        }
    }

    private void Damage (GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            ApplyDebuff(e, debuff);
        }
    }

    public void Seek(GameObject _target)
    {
        target = _target;
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    public void SetProjectileSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetExplosionRadius(float _explosionRadius)
    {
        explosionRadius = _explosionRadius;
    }

    public void SetDebuff(GameObject _debuff)
    {
        debuff = _debuff;
    }
}
