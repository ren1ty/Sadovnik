using System;
using UnityEngine;

public static class CoinController
{

    /// <summary>
    /// Adds the assigned amount to the player's balance
    /// </summary>
    /// <param name="Coins"></param>
    public static void AddCoins(int Coins)
    {
        int tmp = PlayerPrefs.GetInt("Coins");
        tmp += Coins;
        PlayerPrefs.SetInt("Coins", tmp);
    }


    /// <summary>
    /// Removes a certain amount from the player's balance if it does not exceed his balance. Returns TRUE on successful purchase.
    /// </summary>
    /// <param name="Cost"></param>
    /// <returns></returns>
    public static bool ReduceCoins(int Cost)
    {
        int tmp = PlayerPrefs.GetInt("Coins");

        if (tmp >= Cost)
        {
            tmp -= Cost;
            PlayerPrefs.SetInt("Coins", tmp);
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Returns the current number of coins on the player's account
    /// </summary>
    /// <returns></returns>
    public static int GetCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }
}