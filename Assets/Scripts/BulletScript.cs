using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 10;

	void Start()
	{
		// Destroy the bullet after 3 seconds 
		Destroy(gameObject, 3f);
	}

	void Update()
	{

		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{

		if (hitInfo.CompareTag("Player") || hitInfo.name == "Confiner")
		{
			return;
		}

		if (hitInfo.CompareTag("Enemy"))
		{
			Debug.Log("Hit an enemy: " + hitInfo.name);
		}

		if (hitInfo.CompareTag("Wall"))
		{
			Debug.Log("Bullet hit a wall.");
		}

		// Destroy the bullet on collision with anything else
		Destroy(gameObject);
	}
}