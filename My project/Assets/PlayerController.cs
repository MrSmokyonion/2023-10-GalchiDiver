

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Refences")]
    public Rigidbody2D rigid;
    public Transform crosshairTR;
    public GameObject projectilePrefab;
    public GameObject attackRange;
    
    [Header("Parameter")]
    public float speed;
    public float clawPower = 5f;

    private bool moveActive = true;

    private void Update()
    {
        ClawAttack();
        SpoonAttack();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!moveActive)
            return;
        
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

    private void ClawAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = dir - transform.position;
            rigid.AddForce(dir.normalized * clawPower, ForceMode2D.Impulse);
            if (crosshairTR.position.x > transform.position.x)
            {
                attackRange.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                attackRange.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            attackRange.SetActive(true);
            Invoke("disableAttack", 0.2f);
        }
    }

    private void disableAttack()
    {
        attackRange.SetActive(false);
    }

    private void SpoonAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = dir - transform.position;
            
            GameObject obj = Instantiate(projectilePrefab, transform.position, transform.rotation);

            return;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(dir.normalized * clawPower, ForceMode2D.Impulse);            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Escape Port"))
        {
            gameObject.SetActive(false);
            GameManager._instance.Escape();
        }
    }
}
