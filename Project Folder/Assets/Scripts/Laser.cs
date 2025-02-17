﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    private void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.LookAt(target);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyLaser();
        }    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            DestroyLaser();
        }
    }

    void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
