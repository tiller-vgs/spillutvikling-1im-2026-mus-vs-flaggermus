using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	[Header("Damage Settings")]
	public int damage = 5; // Amount of damage the enemy deals per hit

	[Header("Attack Speed Settings")]
	public float attackCooldown = 1f; // Time between attacks in seconds (attack speed)
	private float nextAttackTime = 0f; // The time when the enemy can attack again

	private void OnCollisionStay2D(Collision2D collision)
	{
		// Check if the object we are touching has the "Player" tag
		if (collision.gameObject.CompareTag("Player"))
		{
			// Check if enough time has passed since the last attack
			if (Time.time >= nextAttackTime)
			{
				// Get the PlayerHealth component from the player
				PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

				// If the component exists, proceed with the attack
				if (playerHealth != null)
				{
					//Deal damage
					playerHealth.TakeDamage(damage);
					}
					{ 
					//  Set the time for the next attack
					nextAttackTime = Time.time + attackCooldown;
				}
			}
		}
	}
}