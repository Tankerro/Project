using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    public float speed;
    public int HP = 3;
    public float TimeBtwAttacks;
    public float StratTimeBtwAttacks;
    void Start()
    {
        
    }


    void Update()
    {
        // считает дистанцию до игрока 
        float dist = Vector3.Distance(Player.position, transform.position);

        // если дистанция меньше чем предел, то идти за игроком 
        if (dist < 50f && Player.position.x < transform.position.x)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (dist < 50f && Player.position.x > transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (dist <= 1.5f && TimeBtwAttacks <= 0)
        {
            Player.GetComponent<Player_controller>().TakeDamage();    
            TimeBtwAttacks = StratTimeBtwAttacks;
        }


        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        // TimeBtwAttacks -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        TimeBtwAttacks -= Time.deltaTime;
    }

    // получение урона
    public void TakeDamage()
    {
        HP -= 1;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(TimeBtwAttacks <= 0)
    //     {
    //         if (collision.gameObject.tag == "Player")
    //         {
    //             collision.gameObject.GetComponent<Player_controller>().TakeDamage();    
    //             TimeBtwAttacks = StratTimeBtwAttacks;
    //         }
    //     }

    // }
}
