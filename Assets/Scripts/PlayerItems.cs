using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int totalWood;
    [SerializeField] private int totalCarrots;
    [SerializeField] private int totalFishes;
    [SerializeField] private float currentWater;

    [Header("Limits")]
    [SerializeField] private float waterLimit = 50;
    [SerializeField] private float woodLimit = 10;
    [SerializeField] private float carrotLimit = 5;
    [SerializeField] private float fishLimit = 3;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public int TotalCarrots { get => totalCarrots; set => totalCarrots = value; }
    public int TotalFishes { get => totalFishes; set => totalFishes = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }

    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public float CarrotLimit { get => carrotLimit; set => carrotLimit = value; }
    public float FishLimit { get => fishLimit; set => fishLimit = value; }

    public void SetWaterLimit(float water)
    {
        if (currentWater < WaterLimit)
        {
            currentWater += water;
        }
    }
}
