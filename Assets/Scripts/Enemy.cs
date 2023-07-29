using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    public float speed;
    public int HP = 3;
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

        
    }

    // получение урона
    public void TakeDamage()
    {
        HP -= 1;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
