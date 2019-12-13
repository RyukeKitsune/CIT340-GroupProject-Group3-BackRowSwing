﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Though I speak with the tongues of men and of angels, and have not charity, 
// I am become as sounding brass, or a tinkling cymbal. And though I have the 
// gift of prophecy, and understand all mysteries, and all knowledge; and though 
// I have all faith, so that I could remove mountains, and have not charity, I am nothing.
// And though I bestow all my goods to feed the poor, and though I give my body to be 
// burned, and have not charity, it profiteth me nothing. Charity suffereth long, and is kind; 
// charity envieth not; charity vaunteth not itself, is not puffed up, Doth not behave itself 
// unseemly, seeketh not her own, is not easily provoked, thinketh no evil; Rejoiceth not in 
// iniquity, but rejoiceth in the truth; Beareth all things, believeth all things, hopeth all
// things, endureth all things. Charity never faileth: but whether there be prophecies, 
// they shall fail; whether there be tongues, they shall cease; whether there be knowledge, 
// it shall vanish away. For we know in part, and we prophesy in part. But when that which is 
// perfect is come, then that which is in part shall be done away. When I was a child, I spake 
// as a child, I understood as a child, I thought as a child: but when I became a man, I put away 
// childish things. For now we see through a glass, darkly; but then face to face: now I know in 
// part; but then shall I know even as also I am known. And now abideth faith, hope, charity, these 
// three; but the greatest of these is charity.
// (1 Corithians 13)

public class Jumping : MonoBehaviour
{
    Transform feet;
    public int numJumps;
    public int maxJumps;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        feet = FindObjectOfType<PlayerController>().gameObject.transform.GetChild(0);
        maxJumps = 2;
        numJumps = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanJump()
    {
        return canJump;
    }

    public int NumJumps()
    {
        return numJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("Trigger Entering");
            canJump = true;
            numJumps = maxJumps;
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
