using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I will praise thee; for I am fearfully and wonderfully made: 
// marvellous are thy works; and that my soul knoweth right well.
// (Psalms 139:14 KJV)

public class Weapon : MonoBehaviour
{
    public Projectile proj;
    public GameObject owner;
    

    private void Start()

    {
        owner = FindObjectOfType<PlayerController>().gameObject;
        
    }
    public void Fire()
    {
        if (proj)
        {
            Projectile tempProj;

            tempProj = Instantiate(proj, owner.transform.position + new Vector3(0, 1f, 0), owner.transform.rotation);
            tempProj.GetComponent<Rigidbody2D>().velocity = new Vector2(-owner.GetComponent<PlayerController>().GetDirection().x * proj.GetSpeed(), 0);
        }
    }

}
