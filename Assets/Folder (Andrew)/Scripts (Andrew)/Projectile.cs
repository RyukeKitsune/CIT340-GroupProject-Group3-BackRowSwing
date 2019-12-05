using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Beloved, let us love one another: for love is of God; 
// and every one that loveth is born of God, and knoweth God.
// He that loveth not knoweth not God; for God is love. 
// (1 John 4:7-8 KJV)
public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float lifeTime;
    
    public float GetDamage()
    {
        Debug.Log("Getting Damage");
        return damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Projectile GetProjectile()
    {
        return this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", lifeTime);
        //rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
