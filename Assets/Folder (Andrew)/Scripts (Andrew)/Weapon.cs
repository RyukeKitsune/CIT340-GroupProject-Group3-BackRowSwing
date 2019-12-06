using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// There is no fear in love; but perfect love casteth out fear: 
// because fear hath torment. He that feareth is not made perfect in love.
// We love him, because he first loved us.
// (1 John 4:18-19 KJV)

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
