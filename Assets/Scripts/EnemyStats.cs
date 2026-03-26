using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Enemy stats
    public float health = 100f;
    public float attackDamage = 10f;
    public float walkSpeed = 3f;
    public float attackSpeed = 1f;

    // Who the enemy should follow (usually the player)
    public Transform target;

    NavMeshAgent agent;   // handles movement on the NavMesh
    float attackTimer = 0f; // cooldown between attacks

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // gets the navmeshagent on the enemy
        agent.speed = walkSpeed; 

        // If no target is set, try to find the player by tag
        if (target == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                target = p.transform;
            }
        }
    }

    void Update()
    {
        // If enemy has no health left, it dies
        if (health <= 0)
        {
            Die();
            return;
        }

        // If we have a target, move towards it
        if (target != null)
        {
            agent.SetDestination(target.position);

            // Check how close we are to the target
            float dist = Vector3.Distance(transform.position, target.position);

            // If close enough, try to attack
            if (dist < agent.stoppingDistance + 0.5f)
            {
                if (attackTimer <= 0)
                {
                    Attack();
                    attackTimer = 1f / attackSpeed; // resets attack cooldown
                }
            }
        }

        // Counts down the attack cooldownn
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void Attack()
    {
        // This is where the enemy deals damage
        Debug.Log("Enemy hit player for " + attackDamage);
    }

    public void TakeDamage(float dmg)
    {
        // Reduces enemy health when hit
        health -= dmg;
    }

    void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject); // removes the enemy from the scene
    }
}
using System;

// enemy class that only has HP
public class Enemy
{
    // stores max and current HP
    public int maxHealth;
    public int currentHealth;

    // sets HP when the enemy is created
    public Enemy(int hp)
    {
        maxHealth = hp;
        currentHealth = hp;
    }

    // prints HP info
    public void PrintStats()
    {
        Console.WriteLine("----- Enemy Stats -----");
        Console.WriteLine("HP: " + currentHealth + "/" + maxHealth);
        Console.WriteLine("------------------------");
    }
}

// simple test program
public class Program
{
    public static void Main()
    {

        Enemy bat = new Enemy(67);

        bat.PrintStats();
        bat.PrintStats();

        Console.ReadKey();
    }
}
