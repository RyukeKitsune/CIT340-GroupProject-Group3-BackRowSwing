﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMFollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
    }
}
