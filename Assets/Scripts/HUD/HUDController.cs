using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;


    [Header("Tools")]
    [SerializeField] private List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    private void Start()
    {
        waterUIBar.fillAmount = 0;
        woodUIBar.fillAmount = 0;
        carrotUIBar.fillAmount = 0;
        fishUIBar.fillAmount = 0;
    }

    private void Update()
    {
        waterUIBar.fillAmount = playerItems.CurrentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.WoodLimit;
        carrotUIBar.fillAmount = playerItems.TotalCarrots / playerItems.CarrotLimit;
        fishUIBar.fillAmount = playerItems.TotalFishes / playerItems.FishLimit;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.HandlingObject)
            {
                toolsUI[i].color = selectColor;
            }
            else 
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
