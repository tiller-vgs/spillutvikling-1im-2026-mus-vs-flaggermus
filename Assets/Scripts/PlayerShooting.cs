using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab; // Drag your Bullet Prefab here in the Inspector
	public Transform firePoint;     // Drag your FirePoint object here
	public float bulletForce = 20f;

	void Update()
	{
		// Detect player input (Left Mouse Button)
		if (Input.GetButtonDown("Fire1"))
		{
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
