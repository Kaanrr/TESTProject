using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinCount;

    public void RestartCoinCount()
    {
        coinCount = 0;
    }
    internal void CoinCollected()
    {
        coinCount++;
    }
}
