using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public double oxygen = 77;
    public double MAX_oxygen = 100;
    public int health = 43;
    public int MAX_health = 80;
    public double weight = 0;
    public double MAX_weight = 10;
    public int money = 0;
    
    public Transform playerRef;
    public List<FishData> inventory;
    public List<Transform> spawnPoint_Fish;
    public List<GameObject> prefab_Fishs;
    public Transform spawnPoint_player;
    public GameObject ui_sell;
    public GameObject ui_Endgame;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    private void Start()
    {
        oxygen = MAX_oxygen;
        health = MAX_health;
        weight = 0;
        StartDive();
    }

    public void StartDive()
    {
        oxygen = MAX_oxygen;
        health = MAX_health;
        UpdateCarryWeight();

        foreach (Transform tr in spawnPoint_Fish)
        {
            int random = Random.Range(0, 5);
            Instantiate(prefab_Fishs[random], tr.position, tr.rotation);
        }
        
        playerRef.gameObject.SetActive(true);
        playerRef.position = spawnPoint_player.position;
        
        ui_sell.SetActive(false);
        
        StartCoroutine("OnStartDive");
    }

    IEnumerator OnStartDive()
    {
        yield return null;
        while (oxygen > 0f)
        {
            oxygen -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void StoreItem(FishData fishData)
    {
        inventory.Add(fishData);
        UpdateCarryWeight();
    }

    public void SellItem(int index)
    {
        inventory.RemoveAt(index);
        UpdateCarryWeight();
    }

    private void UpdateCarryWeight()
    {
        weight = 0f;
        foreach (FishData data in inventory)
        {
             weight += data.weight;
        }
    }

    public void Escape()
    {
        ui_sell.SetActive(true);
        SellUIController sellUIController = ui_sell.GetComponent<SellUIController>();
        sellUIController.Init();
    }

    public void EndGame()
    {
        ui_Endgame.SetActive(true);
    }
}
