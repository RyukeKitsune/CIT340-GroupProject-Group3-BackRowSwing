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

    public Projectile GetProjectile()
    {
        Debug.Log("Returning Projectile");
        return proj;
    }

}
