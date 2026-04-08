using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform firePoint;

	public float fireRate = 0.2f;
	private float nextFireTime = 0f;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
		{
			nextFireTime = Time.time + fireRate;
			Shoot();
		}
	}

	void Shoot()
	{
		//Get the mouse position and fix the Z axis
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = firePoint.position.z;

		//Calculate the direction to the mouse
		Vector2 direction = mousePosition - firePoint.position;

		// 3. Math: calculate the rotation angle. 
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		Quaternion rotation = Quaternion.Euler(0, 0, angle - 90f);

		Instantiate(bulletPrefab, firePoint.position, rotation);
	}
}