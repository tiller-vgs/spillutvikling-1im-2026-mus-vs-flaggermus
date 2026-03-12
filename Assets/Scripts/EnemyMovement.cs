using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   // Serialized field to set the movement speed of the enemy in the Unity Inspector
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {   // Calculate the direction from the enemy to the target (player)
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
       if (target)
        {   // Move the enemy towards the target by setting its velocity
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
