using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// And be not conformed to this world: but be ye transformed by the renewing of
// your mind, that ye may prove what is that good, and acceptable, and perfect, will of God.
// (Romans 12:2 KJV)

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health;
    public float jumpHeight;
    public float fireRate;
    public float numJumps;

    bool canJump;
    bool canFire;

    Vector2 direction;

    public Transform playerFeet;
    public GameObject equipped;
    public Projectile proj;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFeet = transform.GetChild(0);
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        equipped = transform.GetChild(1).gameObject;
        numJumps = playerFeet.GetComponent<Jumping>().maxJumps;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
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

        if (fire > 0 && canFire)
        {
            if (equipped != transform.GetChild(1).gameObject)
            {
                canFire = false;
                equipped.GetComponent<Weapon>().Fire();
                Invoke("AllowShooting", 1 / fireRate);
            }
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }

        float jumpValue = Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        canJump = playerFeet.GetComponent<Jumping>().CanJump();
        numJumps = playerFeet.GetComponent<Jumping>().NumJumps();

        if (canJump == true)
        {
            Grounded();
            anim.SetFloat("AirSpeed", 1);
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

    void Jump()
    {
        anim.SetFloat("AirSpeed", -1);
        anim.SetBool("Jump", true);
        anim.SetBool("Grounded", false);

        if (numJumps > 0)
        {
            canJump = false;
            playerFeet.GetComponent<Jumping>().numJumps -= 1;
            rb.AddForce(new Vector2(0, jumpHeight));
            anim.SetBool("Jump", false);
        }

    }

    public GameObject GetEquipped()
    {
        return equipped;
            
    }

    void HurtOff()
    {
        anim.SetBool("Hurt", false);
    }

    void Grounded()
    {
        anim.SetBool("Grounded", true);
        anim.SetBool("Jump", false);
    }


    private void FixedUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
            anim.SetBool("Hurt", true);
            Invoke("HurtOff", 0.5f);
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            equipped = collision.gameObject;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
            proj = equipped.GetComponent<Weapon>().proj;
            //Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            anim.SetBool("Hurt", true);
            Invoke("HurtOff", 0.5f);
            health -= 1;
        }

    }

    public void ChangeHealth(int change)
    {
        health += change;

    }
}