using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbox : MonoBehaviour
{
    int dmg = 999;
    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                collision.gameObject.GetComponent<PlayerController>().ChangeHealth(-dmg);
            }
        }
    }

