using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undead : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject playerBody;
    public Rigidbody2D rb2;
    private PlayerController player;
    public int health = 15;
    public int dmg = 5;
    public Transform target;
    public Transform self;
    public Vector2 moveDirection;


    public void ChangeHealth(int change)
    {
        health += change;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            ChangeHealth(-5);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            moveDirection = self.transform.position - target.transform.position;
            collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-dmg);
            rb.AddForce(moveDirection.normalized * 200f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2 = playerBody.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        target = FindObjectOfType<PlayerController>().transform;
        self = FindObjectOfType<undead>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
