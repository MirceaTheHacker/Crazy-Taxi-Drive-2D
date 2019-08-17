using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundFX : MonoBehaviour
{
    public AudioSource m_IdleSound;
    public AudioSource m_DrivingSound;

    private CarController m_CarController { get { return GetComponentInParent<CarController>(); } }

    void Update()
    {
        if (!Mathf.Approximately(m_CarController.movement, 0) && m_CarController.m_Fuel > 0)
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

    internal void MuteEngineSounds()
    {
        m_IdleSound.mute = true;
        m_DrivingSound.mute = true;
    }

    internal void UnmuteEngineSounds()
    {
        m_IdleSound.mute = false;
        m_DrivingSound.mute = false;
    }
}
