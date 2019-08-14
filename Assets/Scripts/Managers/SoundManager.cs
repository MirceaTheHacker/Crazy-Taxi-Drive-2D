using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip m_GameOverClip;
    public AudioClip m_LoserClip;

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

}
