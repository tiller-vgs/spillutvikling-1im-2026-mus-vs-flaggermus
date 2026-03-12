using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // We declare two public variables: speed, which determines how fast the player moves, and body, which is a reference to the Rigidbody2D component that will be used to apply movement forces to the player
    public float speed;
    public Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        // This method is called once per frame, and it is used to handle input and movement
        float xImput = Input.GetAxisRaw("Horizontal");
        float yImput = Input.GetAxisRaw("Vertical");

        // We create a new Vector2 to represent the direction of movement based on the input, and we normalize it to ensure consistent speed in all directions
        Vector2 direction = new Vector2(xImput, yImput).normalized;
        body.linearVelocity = direction * speed;
    }
}
    