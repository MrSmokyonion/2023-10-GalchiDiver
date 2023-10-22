using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public SpriteRenderer fishSpriteRenderer;
    public FishHealthUIController fishHealthUIController;
    public FishData fishData;
    public GameObject itemPrefab;
    
    private float turnDelay = 2f;
    private float currentMovedTime = 0f;
    private Vector3 moveDir;
    private float currentHP;


    private void Start()
    {
        SetTurnDelayInRandom();
        int temp = Random.Range(0, 2);
        if (temp == 0)
        {
            moveDir = new Vector3(1f, 0f, 0f);
            fishSpriteRenderer.flipX = false;
        }
        else
        {
            moveDir = new Vector3(-1f, 0f, 0f);
            fishSpriteRenderer.flipX = true;
        }

        currentHP = fishData.maxHP;
    }

    private void Update()
    {
        MoveFish();
    }

    private void MoveFish()
    {
        currentMovedTime += Time.deltaTime;
        
        if (currentMovedTime > turnDelay)
        {
            SetTurnDelayInRandom();
            currentMovedTime = 0f;
            moveDir.x *= -1f;
            fishSpriteRenderer.flipX = !fishSpriteRenderer.flipX;
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position+moveDir, Time.deltaTime * moveSpeed);
    }

    private void SetTurnDelayInRandom()
    {
        turnDelay = Random.Range(2f, 4f);
    }

    private void Hit()
    {
        currentHP -= 2;
        if (currentHP <= 0)
        {
            GameObject obj = Instantiate(itemPrefab, transform.position, transform.rotation);
            GrabbableItem grabbableItem = obj.GetComponent<GrabbableItem>();
            grabbableItem.fishData = this.fishData;
            Destroy(gameObject);
        }
        fishHealthUIController.UpdateHealth(currentHP/fishData.maxHP);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("asdasd");
        if (col.CompareTag("AttackCollider"))
        {
            Debug.Log("GotHit");
            Hit();
        }
    }
}
