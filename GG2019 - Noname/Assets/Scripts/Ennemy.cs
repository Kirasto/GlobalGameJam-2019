using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ennemy : Character
{
    [SerializeField]
    float range = 20f;
    NavMeshAgent agent;
    [SerializeField]
    Vector3 offset;
    bool isDead = false;

    Transform player;

    Transform healthBar;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(transform.position);
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar = HealthBarController.CreateHealthBar().transform;
    }
    
    void Update()
    {
        if (isDead)
            return;

        Move();

        healthBar.GetComponent<Slider>().value = currentHealth / maxHealth;

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        healthBar.position = pos + offset;
    }

    void Move()
    {
        if (!canMove)
            return;
        agent.destination = player.transform.position;
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - player.position.x, 2) + Mathf.Pow(transform.position.z - player.position.z, 2)) >= range)
        {
            if (agent.isStopped)
            {
                agent.destination = player.transform.position;
                agent.speed = moveSpeed;
                agent.isStopped = false;
            }
        }
        else if (!agent.isStopped)
        {
            agent.isStopped = true;
            transform.LookAt(player);
            Quaternion vec = transform.rotation;
            vec.x = 0;
            vec.z = 0;
            transform.rotation = vec;
        }

        if (agent.isStopped)
        {
            Attack();
        }
    }

    void Attack()
    {

    }

    public void SetDamage(float damage)
    {
        if (isDead)
            return;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Kill();
    }

    void Kill()
    {
        if (isDead)
            return;
        Destroy(healthBar.gameObject);
        isDead = true;
    }
}
