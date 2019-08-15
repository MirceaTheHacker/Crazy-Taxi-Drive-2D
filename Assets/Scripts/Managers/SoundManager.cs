using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip m_GameOverClip;
    public AudioClip m_LoserClip;
    public AudioClip m_GameWinClip;
    public AudioClip m_ClickClip;
    public AudioClip m_HoverClip;

    private AudioSource m_AudioSource { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        GameManager.Instance.m_SoundManager = this;
    }

    private void PlayOneShot(AudioClip clip)
    {
        m_AudioSource.PlayOneShot(clip);
    }

    internal void PlayGameOverSound()
    {
        PlayOneShot(m_GameOverClip);
    }

    internal void PlayLoserSound()
    {
        PlayOneShot(m_LoserClip);
    }

    internal void PlayGameWinSound()
    {
        PlayOneShot(m_GameWinClip);
    }

    public void PlayClickSound()
    {
        PlayOneShot(m_ClickClip);
    }

    public void PlayHoverSound()
    {
        PlayOneShot(m_HoverClip);
    }

}
