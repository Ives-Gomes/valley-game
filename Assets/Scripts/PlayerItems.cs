using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood;

    public int TotalWood { get => totalWood; set => totalWood = value; }
}
