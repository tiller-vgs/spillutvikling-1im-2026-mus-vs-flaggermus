<<<<<<< Updated upstream
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

        // Counts down the attack cooldown
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
=======
using System;

// basic enemy class with simple stats
public class Enemy
{
    // variables for enemy info
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public float speed;

    // constructor to set up the enemy when created
    public Enemy(string n, int hp, int dmg, int def, float spd)
    {
        maxHealth = hp;
        currentHealth = hp;
        attack = dmg;
        defense = def;
        speed = spd;
    }

    // method for taking damage
    public void TakeDamage(int dmg)
    {
        // reduce incoming damage by defense
        int realDmg = dmg - defense;

        // make sure damage doesn't go negative
        if (realDmg < 0)
            realDmg = 0;

        currentHealth -= realDmg;

        Console.WriteLine(name + " took " + realDmg + " damage. HP: " + currentHealth + "/" + maxHealth);

        // check if enemy died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // method for attacking something
    public int Attack()
    {
        Console.WriteLine(name + " attacks for " + attack + " damage");
        return attack;
    }

    // what happens when HP hits 0
    void Die()
    {
        currentHealth = 0;
        Console.WriteLine(name + " is dead now");
    }

    // prints out the enemy's stats
    public void PrintStats()
    {
        Console.WriteLine("----- Enemy Stats -----");
        Console.WriteLine("HP: " + currentHealth + "/" + maxHealth);
        Console.WriteLine("Attack: " + attack);
        Console.WriteLine("Defense: " + defense);
        Console.WriteLine("Speed: " + speed);
        Console.WriteLine("------------------------");
    }
}

// simple test program to try out the enemy
public class Program
{
    public static void Main()
    {
        // creating a bat enemy
        Enemy bat = new Enemy("Bat", 40, 6, 1, 4.2f);

        bat.PrintStats();
        bat.TakeDamage(12);
        bat.Attack();
        bat.TakeDamage(100);
        bat.PrintStats();

        Console.ReadKey();
    }
}
>>>>>>> Stashed changes
