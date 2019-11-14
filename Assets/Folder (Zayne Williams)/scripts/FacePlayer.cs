using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float range = 5;
    // Update is called once per frame
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }
    void Update()
    {
        float x1 = gameObject.transform.position.x;
        float y1 = gameObject.transform.position.y;

        float x2 = target.transform.position.x;
        float y2 = target.transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow((y2 - y1), 2) + Mathf.Pow((x2 - x1), 2)) < range)
        {
            Vector2 betaVec = target.position - transform.position;
            float angle = Mathf.Atan2((betaVec.y), betaVec.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis((angle), Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}