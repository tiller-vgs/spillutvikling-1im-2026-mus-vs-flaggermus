using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        float xImput = Input.GetAxisRaw("Horizontal");
        float yImput = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(xImput, yImput).normalized;
        body.linearVelocity = direction * speed;
    }
}
    