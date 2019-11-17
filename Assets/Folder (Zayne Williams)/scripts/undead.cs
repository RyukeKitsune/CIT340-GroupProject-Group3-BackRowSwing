using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undead : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;
    public int health = 15;
    public int dmg = 5;


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
            collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-dmg);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
