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
		// Create the bullet at the FirePoint's position and rotation
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

		// Add force to the bullet to make it move
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
	}
}