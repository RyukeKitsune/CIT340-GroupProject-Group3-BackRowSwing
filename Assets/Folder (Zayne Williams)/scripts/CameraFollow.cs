using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;

    void Start()
    {
        objectToFollow = FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
       // if (objectToFollow != null)
       // {
            Vector3 pos = objectToFollow.transform.position;

            gameObject.transform.position =
                new Vector3(pos.x, pos.y, gameObject.transform.position.z);
      //  }
    }
}