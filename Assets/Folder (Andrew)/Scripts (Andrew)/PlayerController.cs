using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//And be not conformed to this world: but be ye transformed by the renewing of your mind, that ye may prove what is that good, and acceptable, and perfect, will of God.
//(Romans 12:2 KJV)

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health;
    public float jumpHeight;
    bool canJump;
    Transform playerFeet;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0);
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float jumpValue = Input.GetAxis("Jump");

        if (moveX != 0)
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
            anim.SetInteger("AnimState", 2);

            if (moveX > 0)
                sr.flipX = true;
            else
                sr.flipX = false;


        }
        else
            anim.SetInteger("AnimState", 0);

        if (jumpValue > 0)
        {
            //Need to fix this, so for now you can fly
            Collider2D[] collisions = Physics2D.OverlapBoxAll(playerFeet.position, new  Vector2(playerFeet.position.x, playerFeet.position.y), 180);

            for (int i = 0; i < collisions.Length; ++i)
            {
                if (collisions[i].gameObject != gameObject)
                {
                    canJump = true;
                    //Debug.Log(canJump);
                    break;
                }

            }
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpHeight));
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
        }
    }
}
