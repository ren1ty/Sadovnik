using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flower : MonoBehaviour
{

    public string FlowerName;
    [Header("Plant stats")]
    [SerializeField] private int health;
    [SerializeField] private int PlantLevel;


    public Flower(string Name)
    {
        this.FlowerName = Name;
    }
    

    /// <summary>
    /// Reduces the health of the plant, destroying it at zero health value
    /// </summary>
    /// <param name="damage"></param>
    /// <exception cref="ArgumentException"></exception>
    public void TakeDamage(int damage)
    {
        if (damage < 0) throw new ArgumentException("The object cannot take negative damage");

        health -= damage;
        //Death;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    /// Called when the Action "OnPlantWatered" is triggered
    private void OnPlantWatered()
    {
        switch (PlantLevel)
        {
            case 1: CoinController.AddCoins(4); break;

            case 2: CoinController.AddCoins(20); break;

            case 3: CoinController.AddCoins(80); break;

        }
    }




    private void OnEnable()
    {
        FlowerWateringSystem.OnPlantWatered += OnPlantWatered;
    }

    private void OnDisable()
    {
        FlowerWateringSystem.OnPlantWatered -= OnPlantWatered;
    }

}
