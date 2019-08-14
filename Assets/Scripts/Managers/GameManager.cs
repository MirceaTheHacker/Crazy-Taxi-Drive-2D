using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    internal FuelManager m_FuelManager;
    internal CarManager m_CarManager;
    internal UIManager m_UIManager;
    internal float m_RespawnLevel;
    internal SoundManager m_SoundManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    internal void GameOverHandler()
    {
        StartCoroutine(m_UIManager.GameOver());
        m_SoundManager.PlayGameOverSound();
    }



}
