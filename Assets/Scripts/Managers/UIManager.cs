using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject m_GameOver;
    public GameObject m_GameWin;
    public GameObject m_ControlUI;
    public GameObject m_CreditsUI;
    public AnimationClip m_CreditsAnimation;

    private void Start()
    {
        GameManager.Instance.m_UIManager = this;
    }

    internal IEnumerator GameOver()
    {
        m_GameOver.SetActive(true);
        yield return new WaitForSeconds(4);
        m_GameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    internal void ShowGameWinUI()
    {
        m_ControlUI.SetActive(false);
        m_GameWin.SetActive(true);
    }

    internal void HideGameWinUI()
    {
        m_ControlUI.SetActive(true);
        m_GameWin.SetActive(false);
    }


    internal IEnumerator ShowCreditsUI()
    {
        m_CreditsUI.SetActive(true);
        yield return new WaitForSeconds(m_CreditsAnimation.length);
        m_CreditsUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
