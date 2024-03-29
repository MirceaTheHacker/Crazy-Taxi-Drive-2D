﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    internal FuelManager m_FuelManager;
    internal CarManager m_CarManager;
    internal UIManager m_UIManager;
    internal float m_RespawnLevel;
    internal SoundManager m_SoundManager;
    internal NitroHandler m_NitroHandler;
    internal InputManager m_InputManager;
    internal CoinManager m_CoinManager;
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

    internal IEnumerator GameOverHandler()
    {

        m_SoundManager.PlayGameOverSound();
        yield return StartCoroutine(m_UIManager.GameOver());
        ReloadLevel();
    }

    internal void GameWinHandler()
    {
        m_UIManager.ShowGameWinUI();
        m_SoundManager.PlayGameWinSound();
        DisableCar();
    }

    private void DisableCar()
    {
        m_CarManager.StopCar();
        m_CarManager.DisableCarScripts();
        m_CarManager.enabled = false;
    }

    public void PlayAgain()
    {
        m_UIManager.HideGameWinUI();
        ReloadLevel();
    }

    public void PlayCredits()
    {
        m_UIManager.HideGameWinUI();
        StartCoroutine(m_UIManager.ShowCreditsUI());
    }


    private void ReloadLevel()
    {
        m_NitroHandler.OnLevelReset();
        m_InputManager.webGLmovement = 0;
        m_UIManager.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }




}
