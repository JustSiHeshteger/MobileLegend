using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMove : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveForce = 10f;
    private bool isGrounded;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    private void FixedUpdate() {
        CheckGround();
    } 

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
            Debug.Log("Прыжок сделан");
        }
    }

    private void Move() {
        float getMoveSide = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(getMoveSide * moveForce, rb.velocity.y);
    }

    private void CheckGround() {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
}
