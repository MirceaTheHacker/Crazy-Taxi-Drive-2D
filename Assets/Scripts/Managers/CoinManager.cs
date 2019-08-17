using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    internal int m_CoinsNo = 0;
    private TextMeshProUGUI m_Text { get { return GetComponentInChildren<TextMeshProUGUI>(); } }


    private void Start()
    {
        GameManager.Instance.m_CoinManager = this;
        SetCoinsNo();
    }

    private void SetCoinsNo()
    {
        m_Text.text = " " + m_CoinsNo;
    }

    internal void AddCoins(int number)
    {
        m_CoinsNo += number;
        SetCoinsNo();
    }
}
