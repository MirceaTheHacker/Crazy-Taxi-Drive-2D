using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject m_GameOver;

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
}
