using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : MonoBehaviour
{
    public float moveSpeed = 1f;
    public FishData fishData; 
    
    private bool detectPlayer = false;
    private Transform playerRef;

    private void Start()
    {
        playerRef = GameManager._instance.playerRef;
    }

    void Update()
    {
        if (detectPlayer)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerRef.position, Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Detect Item"))
        {
            detectPlayer = true;
            return;
        }
        if (col.CompareTag("Get Item"))
        {
            //TODO:인벤토리에 수납
            GameManager._instance.StoreItem(fishData);
            
            Destroy(gameObject);
        }
    }
}
