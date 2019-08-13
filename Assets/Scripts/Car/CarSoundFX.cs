using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundFX : MonoBehaviour
{
    public AudioSource m_IdleSound;
    public AudioSource m_DrivingSound;
    void Update()
    {
        if (!Mathf.Approximately(Input.GetAxisRaw("Vertical"), 0))
        {
            if (!m_DrivingSound.isPlaying)
                m_DrivingSound.Play();
            m_IdleSound.Pause();
        }
        else
        {

            m_DrivingSound.Pause();
            if (!m_IdleSound.isPlaying)
                m_IdleSound.Play();
        }
    }
}
