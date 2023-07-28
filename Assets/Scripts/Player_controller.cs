using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool IsGrounded = false;
    public float moveHorizontal;
    public float moveVertical;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
}
