using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//And be not conformed to this world: but be ye transformed by the renewing of
//your mind, that ye may prove what is that good, and acceptable, and perfect, will of God.
//(Romans 12:2 KJV)

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health;
    public float jumpHeight;
    public float fireRate;

    bool canJump;
    bool canFire;

    Vector2 direction;

    Transform playerFeet;
    public Weapon equipped;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0);
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float jumpValue = Input.GetAxis("Jump");
        float fire = Input.GetAxis("Fire1");

        if (moveX != 0)
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
            anim.SetInteger("AnimState", 2);

            if (moveX > 0)
            {
                //sr.flipX = true;
                gameObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
                direction = transform.right;
            }
            else
            {
                //sr.flipX = false;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                direction = transform.right;

            }


        }
        else
            anim.SetInteger("AnimState", 0);

        if (jumpValue > 0)
        {
            //Need to fix this, so for now you can fly
            Collider2D[] collisions = Physics2D.OverlapBoxAll(playerFeet.position, new Vector2(playerFeet.position.x, playerFeet.position.y), 180);

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

        if (fire > 0 && canFire)
        {
            canFire = false;
            GameObject bullet =
            Instantiate(equipped.GetProjectile().gameObject, equipped.transform.position, equipped.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-direction.x * equipped.GetProjectile().GetSpeed(), 0);
            Invoke("AllowShooting", 1 / fireRate);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    void AllowShooting()
    {
        canFire = true;
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
    public void ChangeHealth(int change)
    {
        health += change;

    }
}