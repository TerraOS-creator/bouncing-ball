using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;
    public float speed = 10.0f;
    private Vector2 direction;
    private Vector3 mousePosition;
    private Rigidbody2D rigidBody2D; 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;

        rigidBody2D.velocity = velocity;

        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rigidBody2D.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }
}
