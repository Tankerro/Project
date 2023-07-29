using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float BulletSpeed;
    public Player_controller PlayerRotation;
    void Start()
    {
        PlayerRotation = GameObject.Find("Pupsik").GetComponent<Player_controller>();
        if (PlayerRotation.faceOnRight == true)
        {
            BulletSpeed = 150f;
        }

        else if (PlayerRotation.faceOnRight == false)
        {
            BulletSpeed = -150f;
        }
    }

    void Update()
    {      
        rb.velocity = new Vector2(BulletSpeed, rb.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
