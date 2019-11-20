using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
  
    public int health = 15;
    public int dmg = 5;
    public Transform target;
    public float ammount = 0.2f;
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
            gameObject.transform.position = (target.transform.position + target.transform.position * ammount);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
