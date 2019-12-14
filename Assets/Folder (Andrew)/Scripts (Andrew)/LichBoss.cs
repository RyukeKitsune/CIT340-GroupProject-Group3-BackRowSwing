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
    public GameObject magicPortal;
    public GameObject attack3;
    public GameObject targetPlayer;
    public GameObject floor;

    public float attackWait;
    public float attack1Speed;
    public float attack2Lifetime;
    public float attack2Charge;
    public float portalPull;

    public int health;

    bool portalActive;
    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        portalActive = false;
        targetPlayer = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (canAttack)
        {
            if (Random.value < .3f)
                MagicPortal();
            else
                MagicBolt();

            Debug.Log(Random.value);
            Invoke("AllowAttack", attackWait);
        }

        //Debug.Log(targetPlayer.transform.position);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void AllowAttack()
    {
        canAttack = true;
    }

    IEnumerator PullPlayer(Vector2 portal)
    {
        yield return new WaitForSeconds(0.1f);
        Vector2 direction;
        direction = new Vector2(targetPlayer.transform.position.x - portal.x, targetPlayer.transform.position.y - portal.y);

        if (portalActive)
        {
            Debug.Log("In PullPlayer");
            targetPlayer.GetComponent<Rigidbody2D>().AddForce(new Vector2(portalPull * -direction.x, 0));
            StartCoroutine(PullPlayer(portal));
        }
    }

        void MagicBolt()
        {
            GameObject bolt;
            bolt = Instantiate(magicBolt, transform.position + new Vector3(0, Random.Range(-.5f, .5f)), transform.rotation);
            bolt.GetComponent<Rigidbody2D>().AddForce(new Vector2(attack1Speed * Time.deltaTime * -transform.right.x, 0));
            StartCoroutine(Die(bolt));
            canAttack = false;
            attackWait = 2;
        }

        void MagicPortal()
        {
            GameObject portal; 
            portal = Instantiate(magicPortal, Vector3.Scale(targetPlayer.transform.position, (new Vector3(1, 0, 0))) + new Vector3(Random.Range(-2, 2), floor.GetComponent<BoxCollider2D>().bounds.max.y + 1f), transform.rotation);
            portalActive = true;
            StartCoroutine(PullPlayer(portal.transform.position));
            StartCoroutine(Portal(portal));
            StartCoroutine(Die(portal));
            canAttack = false;
            attackWait = 7;
        }

        IEnumerator Portal(GameObject g)
        {
            yield return new WaitForSeconds(attack2Charge);
            Debug.Log("In Portal");
            Animator anim = g.GetComponent<Animator>();
            anim.SetBool("Charged", true);
            g.GetComponent<BoxCollider2D>().enabled = true;
            portalActive = false;
        }

        IEnumerator Die(GameObject g)
        {
            yield return new WaitForSeconds(attack2Lifetime);
            Debug.Log("In die");
            Destroy(g);
        }

        void ChangeHealth(int c)
        {
            health += c;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
                ChangeHealth(-2);
            }
        }
    }
