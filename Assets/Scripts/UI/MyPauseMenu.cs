using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
    public GameObject m_PauseMenu;
    [HideInInspector] public static bool GameIsPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        m_PauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        GameManager.Instance.m_CarManager.m_CarSoundFX.UnmuteEngineSounds();
    }

    public void Pause()
    {
        m_PauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        GameManager.Instance.m_CarManager.m_CarSoundFX.MuteEngineSounds();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        m_PauseMenu.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
