using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab; // Drag your Bullet Prefab here in the Inspector
	public Transform firePoint;     // Drag your FirePoint object here
	public float bulletForce = 20f;

	// --- Variables for fire rate control ---
	public float fireRate = 0.2f;    // Time in seconds between shots (0.2 = 5 shots per second)
	private float nextFireTime = 0f; // Stores the time when the next shot can be fired

	void Update()
	{
		// Using GetButton instead of GetButtonDown for automatic firing when holding LMB.
		// Also checking if the current game time is greater than or equal to the next allowed fire time.
		if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
		{
			// Set the time for the next shot
			nextFireTime = Time.time + fireRate;
			Shoot();
		}
	}

	void Shoot()
	{
		// 1. Get the mouse position in world space
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// 2. Calculate the direction vector from firePoint to mouse position
		Vector2 direction = (mousePosition - firePoint.position).normalized;


		// 4. Instantiate the bullet
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

		// 5. Apply velocity using the calculated direction vector
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			rb.linearVelocity = direction * bulletForce;
		}
	}
}