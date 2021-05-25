using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private PlayerStats playerStatsInstance;

    [Header("Stats")]
    public float attack = 10f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float speed = 10f;
    public float startHealth = 100f;
    private float health;
    public int value = 1;
    [HideInInspector]
    public float currentSpeed;
    [HideInInspector]
    public GameObject slow;

    [Header("Effects")]
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public string meleeTag = "Melee";
    public GameObject enemyUI;
    public Image healthBar;
    private Transform mainCamera;

    private GameObject blocking;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        currentSpeed = speed;
        health = startHealth;
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        SetPosition();
        
        if(blocking != null && attackCooldown <= 0f)
        {
            blocking.GetComponent<Melee>().TakeDamage(attack);
            attackCooldown = 1f / attackSpeed;
        }

        attackCooldown -= Time.deltaTime;
    }

    private void Die()
    {
        deathEffect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        if(blocking != null)
        {
            blocking.GetComponent<Melee>().ReduceBlocked(gameObject);
        }
        
        WaveSpawner.EnemiesAlive--;

        
        Destroy(gameObject);

        playerStatsInstance.AddDP(value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == meleeTag)
        {
            blocking = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == meleeTag)
        {
            blocking = null;
        }
    }

    private void ResetSlow()
    {
        slow = null;
        CancelInvoke();
    }

    private void SetPosition()
    {
        enemyUI.GetComponent<RectTransform>().rotation = mainCamera.rotation;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void DebuffSlow(GameObject debuff)
    {
        if (slow == null)
        {
            slow = debuff;
            slow.GetComponent<SlowDebuff>().target = this;
            Instantiate(slow);
            Invoke("ResetSlow", 1f);
        }
    }

    public void Slow(float pct)
    {
        currentSpeed = speed * (1f - pct);
    }
}
