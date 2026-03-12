using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	[Header("Damage Settings")]
	public int damage = 5; // Amount of damage the enemy deals per hit

	// Using OnCollisionStay2D so the enemy constantly tries to deal damage
	// while touching the player. The player's invincibility frames will 
	// protect them from taking damage every single frame.
	private void OnCollisionStay2D(Collision2D collision)
	{
		// Check if the object we are touching has the "Player" tag
		if (collision.gameObject.CompareTag("Player"))
		{
			// Get the PlayerHealth component from the player
			PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

			// If the component exists, try to deal damage
			if (playerHealth != null)
			{
				playerHealth.TakeDamage(damage);
			}
		}
	}

	// Alternative: If your enemy is a trigger (like a trap, fire, or poison area)
	// and passes through the player without physical collision, use this instead:
	/*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
    */
}