using UnityEngine;

//For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.
//(John 3:16 KJV)

//Whosoever shall confess that Jesus is the Son of God, God dwelleth in him, and he in God.
//And we have known and believed the love that God hath to us. God is love; and he that dwelleth in love dwelleth in God, and God in him.
//(1 John 4:15-16 KJV)

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    void Start()
    {

    }

    void Update()
    {
        if (objectToFollow != null)
        {
            Vector3 pos = objectToFollow.transform.position;

            gameObject.transform.position =
                new Vector3(pos.x, pos.y, gameObject.transform.position.z);
        }
    }
}