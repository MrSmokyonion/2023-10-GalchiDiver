using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 dir = Vector3.zero; 
        if (Input.GetKey(KeyCode.W))
        {
            dir.y += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.x -= 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.y -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x += 1f;
        }

        if (dir.x == 0f && dir.y == 0f)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position+dir, Time.deltaTime * speed);
        rigid.velocity = Vector2.zero;
        //transform.Translate(transform.position + dir);
    }
}
