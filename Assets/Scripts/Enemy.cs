using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerStats playerStatsInstance;

    [Header("Stats")]
    public float speed = 10f;
    public float health = 100f;
    public int value = 1;
    [HideInInspector]
    public float currentSpeed;

    [Header("Effects")]
    public GameObject deathEffect;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        currentSpeed = speed;
    }

    private void Die()
    {
        deathEffect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);

        playerStatsInstance.AddDP(value);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        currentSpeed = speed * (1f - pct);
    }
}
