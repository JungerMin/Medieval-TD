using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Melee : Units
{
    [Header("Melee Stats")]
    public float startHealth = 100f;
    private float health;
    public int blockCount;
    public int dmgPerHit;
    private bool alive = true;

    private int blocked = 0;
    private List<GameObject> colliding = new List<GameObject>();

    [Header("Unity Stuff")]
    public Image healthBar;
    public GameObject unitUI;
    private Transform mainCamera;

    private void Awake()
    {
        health = startHealth;
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        SetUIPosition();

        if (alive)
        {
            if (target == null)
            {
                animator.Play("Base Layer.Idle");
                return;
            }

            LockOnTarget();
            Attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (alive)
        {

            colliding.Add(collision.gameObject);

            if (collision.gameObject.tag == enemyTag && blocked < blockCount)
            {
                collision.gameObject.GetComponent<EnemyMovement>().Blocked();
                blocked++;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (alive)
        {
            colliding.Remove(collision.gameObject);
        }      
    }

    private void SetUIPosition()
    {
        unitUI.GetComponent<RectTransform>().rotation = mainCamera.rotation;
    }

    private void Hit()
    {
        if (alive) 
        { 
            for (int i = 0; i < colliding.Count; i++)
            {
                GameObject enemy = colliding[i];
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(dmgPerHit);
                }
            }
        }
    }

    private void Die()
    {
        RemoveBlocked();
        animator.Play("Base Layer.Die");
        Destroy(gameObject, 2f);
    }

    public void ReduceBlocked(GameObject _enemy)
    {
        colliding.Remove(_enemy);
        blocked--;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            alive = false;
            Die();
        }
    }

    public void RemoveBlocked()
    {
        for (int i = 0; i < colliding.Count; i++)
        {
            colliding[i].GetComponent<EnemyMovement>().NotBlocked();
        }
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }
}
