using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish Data", menuName = "Scriptable Object/Fish Data", order = int.MaxValue)]
public class FishData : ScriptableObject
{
    [SerializeField]
    public string name;
    [SerializeField]
    public float maxHP;
    [SerializeField]
    public int price;

    [SerializeField] public float weight;
}
