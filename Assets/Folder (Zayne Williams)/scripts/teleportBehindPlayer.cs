using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportBehindPlayer : MonoBehaviour
{
    public Transform target;
    public Transform self;
    public float telerange = 20;
    public float teleportDelay = 0.2f;
    public float ammount = 0.2f;
    bool canTP = true;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }
    void AllowTP()
    {
        canTP = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x1 = gameObject.transform.position.x;
        float y1 = gameObject.transform.position.y;

        float x2 = target.transform.position.x;
        float y2 = target.transform.position.y;
        if (Mathf.Sqrt(Mathf.Pow((y2 - y1), 2) + Mathf.Pow((x2 - x1), 2)) < telerange)
        {

            if (canTP)
            {

                gameObject.transform.position = (target.transform.position + target.transform.position * ammount) ;
                canTP = false;
                Invoke("AllowTP", 1 / teleportDelay);
            }
        }
        }
}
