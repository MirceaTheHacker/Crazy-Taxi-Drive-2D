using System.Collections;
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
        m_CarManager.m_CarController.enabled = false;
        m_CarManager.m_CarSoundFX.enabled = false;
        m_CarManager.StopCoroutine(m_CarManager.m_OutOfFuelCoroutine);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
