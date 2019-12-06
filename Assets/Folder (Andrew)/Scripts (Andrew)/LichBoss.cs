using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jesus said unto him, Thou shalt love the Lord thy God with all thy heart, 
// and with all thy soul, and with all thy mind. This is the first and great 
// commandment. And the second is like unto it, Thou shalt love thy neighbour 
// as thyself. On these two commandments hang all the law and the prophets.
// (Matthew 22:37-40 KJV)

public class LichBoss : MonoBehaviour
{
    public GameObject magicBolt;
    public GameObject attack2;
    public GameObject attack3;

    public float attackWait;
    public float attack1Speed;

    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (canAttack)
        {
            MagicBolt();
            Invoke("AllowAttack", attackWait);
        }

    }

    void AllowAttack()
    {
        canAttack = true;
    }

    void MagicBolt()
    {
        GameObject bolt;
        bolt = Instantiate(magicBolt, transform.position, transform.rotation);
        bolt.GetComponent<Rigidbody2D>().AddForce(new Vector2(attack1Speed * Time.deltaTime, 0));
        canAttack = false;
    }
}
