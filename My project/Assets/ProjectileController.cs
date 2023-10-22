using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform playerRef;
    private LineRenderer lineRenderer;
    private Rigidbody2D rigid;
    public Vector3 dir;

    private void Start()
    {
        playerRef = GameManager._instance.playerRef;
        lineRenderer = GetComponent<LineRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = dir - transform.position;
        FireProjectile();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, playerRef.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    public void FireProjectile(float power = 3f)
    {
        rigid.AddForce(dir * power, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            rigid.velocity = Vector2.zero;
            rigid.bodyType = RigidbodyType2D.Static;
            
        }
    }
}
