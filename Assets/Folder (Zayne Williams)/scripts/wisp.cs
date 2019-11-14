using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wisp : MonoBehaviour
{
    public float attackSpeed = 2;
    bool canFire = true;
    public GameObject fireBall;
    private Rigidbody2D rb;
    public GameObject firePoint;
    public Transform target;
    public Transform self;
    public float fireRange = 10;
    public int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = FindObjectOfType<Player>().transform;
        target = FindObjectOfType<PlayerController>().transform;
        self = FindObjectOfType<wisp>().transform;
    }
    void AllowFiring()
    {
        canFire = true;
    }
    /* public void ChangeHealth(int change)
     {
         health += change;

         if (health <= 0)
         {
             Destroy(gameObject);
         }
     }*/
    // Update is called once per frame
    void Update()
    {
        float x1 = gameObject.transform.position.x;
        float y1 = gameObject.transform.position.y;

        float x2 = target.transform.position.x;
        float y2 = target.transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow((y2 - y1), 2) + Mathf.Pow((x2 - x1), 2)) < fireRange)
        {

            if (canFire)
            {

                Instantiate(fireBall, firePoint.transform.position, firePoint.transform.rotation);
                canFire = false;
                Invoke("AllowFiring", 1 / attackSpeed);
            }
        }
    }
}