using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 5;
    public float lifeTime = 3;
    public int dmg = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-dmg);
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
