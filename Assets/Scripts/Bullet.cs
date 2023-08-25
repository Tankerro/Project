using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float BulletSpeed = 20f;
    public Player_controller PlayerRotation;
    public float distance = 0f;
    public LayerMask WhatIsSolid;
    public Vector3 direction;
    void Start()
    {

        PlayerRotation = GameObject.Find("Player").GetComponent<Player_controller>();
        // if (PlayerRotation.faceOnRight == true)
        // {
        //     BulletSpeed = 20f;
        // }

        // else if (PlayerRotation.faceOnRight == false)
        // {
        //     BulletSpeed = -20f;
        // }

        if(PlayerRotation.faceOnRight == true)
        {
            direction = Vector3.right;

        }

        else if(PlayerRotation.faceOnRight == false)
        {
            direction = Vector3.left * -1f;
        }
    }

    void Update()
    {      
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, WhatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage();
            }
            Destroy(gameObject);
        }

        transform.Translate(direction * Time.deltaTime * BulletSpeed);
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         collision.gameObject.GetComponent<Enemy>().TakeDamage();
    //         Destroy(gameObject);
    //     }

    //     Destroy(gameObject);
    // }
}
