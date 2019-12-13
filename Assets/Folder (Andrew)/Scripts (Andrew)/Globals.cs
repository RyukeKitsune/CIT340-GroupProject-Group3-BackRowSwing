using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Let nothing be done through strife or vainglory; 
// but in lowliness of mind let each esteem other 
// better than themselves. Look not every man on his 
// own things, but every man also on the things of 
// others. Let this mind be in you, which was also in 
// Christ Jesus: Who, being in the form of God, thought 
// it not robbery to be equal with God: But made himself 
// of no reputation, and took upon him the form of a 
// servant, and was made in the likeness of men: And being
// found in fashion as a man, he humbled himself, and became
// obedient unto death, even the death of the cross.

public class Globals : MonoBehaviour
{
    public GameObject targetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
