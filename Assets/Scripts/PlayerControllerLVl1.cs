using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLVl1 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;
    public bool IsGrounded = false;
    public float moveHorizontal;
    public bool faceOnRight;
    public float JForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        }



        if (moveHorizontal < 0f && faceOnRight != true)
        {
            transform.Rotate(0, 180, 0);
            faceOnRight = true;
        }
        else if (moveHorizontal > 0f && faceOnRight == true)
        {
            transform.Rotate(0, 180, 0);
            faceOnRight = false;
        }



        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(new Vector2(0f, JForce), ForceMode2D.Impulse);
            IsGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }


}
