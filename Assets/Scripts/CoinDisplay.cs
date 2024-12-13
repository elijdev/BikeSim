using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    int coins;

    void FixedUpdate()
    {
        coins = FindObjectOfType<CoinManager>().GetTotalCoins();
        coinText.text = $"{coins}";
    }

}
