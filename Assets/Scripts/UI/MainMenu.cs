using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        GameManager.Instance.m_UIManager.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void PlayClickSound()
    {
        GameManager.Instance.m_SoundManager.PlayClickSound();
    }

    public void PlayHoverSound()
    {
        GameManager.Instance.m_SoundManager.PlayHoverSound();
    }

}
