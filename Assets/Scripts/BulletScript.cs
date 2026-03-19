using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage = 10; // How much damage the bullet deals

	void Start()
	{
		// Destroy the bullet after 3 seconds if it hits nothing
		Destroy(gameObject, 3f);
	}

	// This method triggers when the bullet collides with another object
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		// Ignore collision with the player
		if (hitInfo.CompareTag("Player"))
		{
			return; // Exit the method, the bullet keeps flying
		}

		//  Check if we hit an enemy
		if (hitInfo.CompareTag("Enemy"))
		{
			Debug.Log("Hit an enemy! Object: " + hitInfo.name);

			// Placeholder for dealing damage:
			// Enemy enemy = hitInfo.GetComponent<Enemy>();
			// if (enemy != null) { enemy.TakeDamage(damage); }
		}

		//  If the bullet hits a wall, log a message (optional)
		if (hitInfo.CompareTag("Wall"))
		{
			Debug.Log("Bullet hit a wall.");
		}

		// Log this message to verify what the bullet actually hit
		Debug.Log("Bullet collided with object: " + hitInfo.name + " with tag: " + hitInfo.tag);

		//  Destroy the bullet on any collision (except the player)
		Destroy(gameObject);
	}
}