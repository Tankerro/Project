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
            BulletSpeed = 10f;
        }

        else if (PlayerRotation.faceOnRight == false)
        {
            BulletSpeed = -10f;
        }
    }


    void Update()
    {      
        rb.AddForce(new Vector2(BulletSpeed, 0f), ForceMode2D.Impulse);
    }
}
