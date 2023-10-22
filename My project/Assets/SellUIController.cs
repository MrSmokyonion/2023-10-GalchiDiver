using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellUIController : MonoBehaviour
{
    public List<GameObject> itemList;
    public List<Texture> fishSprites;
    
    public GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager._instance;
    }

    public void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            //있을떄
            if (_gameManager.inventory.Count >= i + 1)
            {
                itemList[i].SetActive(true);
                ItemController itemController = itemList[i].GetComponent<ItemController>();
                itemController.fishName.text = _gameManager.inventory[i].name;
                itemController.fishButton.text = String.Format("판매 {0}", _gameManager.inventory[i].price.ToString());
                /*
                switch (datas[i].name)
                {
                    case "Football":
                        itemController.fishImage.image = fishSprites[0]; break;
                    case "Mackerel":itemController.fishImage.image = fishSprites[1]; break;
                    case "PaleChub":itemController.fishImage.image = fishSprites[2]; break;
                    case "StripedMarlin":itemController.fishImage.image = fishSprites[3]; break;
                    case "Urchin":itemController.fishImage.image = fishSprites[4]; break;
                }
                */
            }
            else //없을때
            {
                itemList[i].SetActive(false);
            }
        }
    }

    public void OnSellButton(int index)
    {
        _gameManager.money += _gameManager.inventory[index].price;
        _gameManager.SellItem(index);
        Init();
        if (_gameManager.money >= 5000)
        {
            _gameManager.EndGame();
        }
    }
}
