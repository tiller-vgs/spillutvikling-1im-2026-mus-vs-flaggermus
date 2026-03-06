using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]private float speed = 100f;
	public Rigidbody2D rb;

	void Start()
	{
        // Shoots the bullet forward (right) based on its rotation
        rb.linearVelocity = transform.right * speed * Time.fixedDeltaTime;
		Object.Destroy(gameObject, 3f);
	}
}