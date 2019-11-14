using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public float range = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        // target = FindObjectOfType<Player>().transform;
        target = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x1 = gameObject.transform.position.x;
        float y1 = gameObject.transform.position.y;

        float x2 = target.transform.position.x;
        float y2 = target.transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow((y2 - y1), 2) + Mathf.Pow((x2 - x1), 2)) < range)
        {

            Vector3 deltaVec = target.position - transform.position;

            deltaVec = Vector3.Normalize(deltaVec);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = deltaVec * speed;
            else
            {
                transform.position += deltaVec * speed * Time.deltaTime;


            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
