using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoUIUpdate : MonoBehaviour
{
    public TextMeshPro oxygenText;
    public TextMeshPro healthText;
    public TextMeshPro weightText;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager._instance;
    }

    private void Update()
    {
        string str1 = String.Format("{0:#}%", Math.Truncate(_gameManager.oxygen));
        oxygenText.text = str1;

        healthText.text = _gameManager.money.ToString();
        
        string str3 = String.Format("{0:0.0}kg\n/{1:0.0}kg", _gameManager.weight, _gameManager.MAX_weight);
        weightText.text = str3;
    }
}
