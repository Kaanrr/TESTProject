using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public CoinUI coinUI;

    public void RestartCoinCount()
    {
        coinCount = 0;
    }
    internal void CoinCollected()
    {
        coinCount++;
        UpdateCoinCountUI();
    }

    public void UpdateCoinCountUI()
    {
        coinUI.SetCoinCount(coinCount);
    }
}
