using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class winLoseActive : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private TextMeshPro moneyText;

    public void Win()
    {
        winText.gameObject.SetActive(true);
        moneyText.gameObject.SetActive(false);
    }
    public void Lose()
    {
        loseText.gameObject.SetActive(true);
        moneyText.gameObject.SetActive(false);
    }
}
