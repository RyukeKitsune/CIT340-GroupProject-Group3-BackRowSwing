using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Though I speak with the tongues of men and of angels, and have not charity, 
// I am become as sounding brass, or a tinkling cymbal. And though I have the 
// gift of prophecy, and understand all mysteries, and all knowledge; and though 
// I have all faith, so that I could remove mountains, and have not charity, I am 
// nothing. And though I bestow all my goods to feed the poor, and though I give 
// my body to be burned, and have not charity, it profiteth me nothing.
// (1 Corithians 13:1-3 KJV)

public class Jumping : MonoBehaviour
{
    Transform feet;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        feet = FindObjectOfType<PlayerController>().gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool CanJump()
    {
        return canJump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("Trigger Entering");
            canJump = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
}
