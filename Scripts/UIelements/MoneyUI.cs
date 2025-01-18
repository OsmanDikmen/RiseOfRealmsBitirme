using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro moneyText;

    private void Update()
    {
        if(GameCoin.playerMoney < 0)
        {
            GameCoin.playerMoney = 0;
        }
        moneyText.text = GameCoin.playerMoney.ToString();
    }
}
