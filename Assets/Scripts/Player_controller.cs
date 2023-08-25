using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 60f;
    public float jumpForce = 5f;
    public bool IsGrounded = false;
    public float moveHorizontal;
    public bool faceOnRight;
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public float range = 5f; 
    public ParticleSystem ShootPartical;
    public int HP = 5;
    public Animator animator;
    public GameObject RestartMenu;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        //считывание нажатий
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // двежение 
        if (moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        }
        
        // прыжок 
        if (Input.GetKey(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            IsGrounded = false;
        }

        // поворот персонажа 
        if (moveHorizontal > 0f && faceOnRight == false)
        {
            transform.Rotate(0, 180, 0);
            faceOnRight = true;
        }

        else if (moveHorizontal < 0f && faceOnRight == true)
        {
            transform.Rotate(0, 180, 0);
            faceOnRight = false;
        }
        
        // если левая кнопка мыши нажата, то стрелять 
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }

    // считывает приземления 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
    
    // стрельба
    public void Shoot()
    {
        Destroy(Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation), 5);
        // if(faceOnRight == true)
        // {
        //     Instantiate(ShootPartical, BulletSpawner.transform.position, Quaternion.Euler(0, 90, -90));
        // }
        // else if(faceOnRight == false)
        // {
        //     Instantiate(ShootPartical, BulletSpawner.transform.position, Quaternion.Euler(270, 90, -90));
        // }

    }

    public void TakeDamage()
    {
        HP -= 1;
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        animator.Play("TakeDamageAnim");
        if(HP <= 0)
        {
            RestartMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
