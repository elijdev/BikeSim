using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    private const string CoinsKey = "PlayerCoins";

    [Header("Coin Settings")]
    public int levelReward;

    private int totalCoins;

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt(CoinsKey, 0);
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        SaveCoins();
    }

    public int AddLevelReward()
    {
        levelReward = Random.Range(30, 50);
        AddCoins(levelReward);
        return levelReward;
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void ResetCoins()
    {
        totalCoins = 0;
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, totalCoins);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }
}
