using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private PlayerStats playerStatsInstance;

    [Header("Stats")]
    public float speed = 10f;
    public float startHealth = 100f;
    private float health;
    public int value = 1;
    //[HideInInspector]
    public float currentSpeed;
    //[HideInInspector]
    public GameObject slow;

    [Header("Effects")]
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public GameObject enemyUI;
    public Image healthBar;
    private Transform mainCamera;

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
    }

    private void Die()
    {
        deathEffect.GetComponent<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);

        playerStatsInstance.AddDP(value);
    }

    private void ResetSlow()
    {
        slow = null;
        CancelInvoke();
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

    private void SetPosition()
    {
        enemyUI.GetComponent<RectTransform>().rotation = mainCamera.rotation;
    }
}
