using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    internal Vector2 m_CheckPoint;
    internal HealthManager m_HealthManager;
    internal CarController m_CarController { get { return GetComponentInChildren<CarController>(); } }

    private Rigidbody2D[] m_Rigidbodies2D { get { return GetComponentsInChildren<Rigidbody2D>(); } }
    private bool isAlive = true;

    private void Start()
    {
        GameManager.Instance.m_CarManager = this;
        HealthSetup();
        m_CheckPoint = gameObject.transform.position;
    }

    private void HealthSetup()
    {
        m_HealthManager = GameManager.Instance.GetComponentInChildren<HealthManager>();
        m_HealthManager.maxHealth = maxHealth;
        m_HealthManager.curHealth = curHealth;
        m_HealthManager.InitializeHarts();
    }

    private void Update()
    {
        CheckIfFellOff();
    }

    internal void Respawn()
    {
        DamagePlayer(1);
        if (curHealth <= 0)
        {
            DeathHandler();
            return;
        }
        m_CarController.transform.position = m_CheckPoint;
        m_CarController.transform.rotation = Quaternion.identity;
        CancelVellocity();
        m_CarController.AddFuel(1);
        GameManager.Instance.m_SoundManager.PlayLoserSound();

    }

    private void CancelVellocity()
    {
        foreach (Rigidbody2D rigidbody in m_Rigidbodies2D)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    private void DamagePlayer(int damageValue)
    {
        curHealth -= damageValue;
        m_HealthManager.UpdateHearts(damageValue);
    }

    private void DeathHandler()
    {
        if (isAlive)
        {
            isAlive = false;
            m_CarController.enabled = false;
            GameManager.Instance.GameOverHandler();
        }

    }


    internal IEnumerator OutOfFuelCoroutine()
    {
        m_CarController.CutMovement();
        m_CarController.backwheel.useMotor = false;
        m_CarController.frontwheel.useMotor = false;
        float direction = m_CarController.m_Rigidbody2d.velocity.x;
        while (m_CarController.m_Rigidbody2d.velocity.x * direction > 0)
        {
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(3);
        if (m_CarController.m_Fuel < 0)
        {
            Respawn();
        }
    }

    private void CheckIfFellOff()
    {
        if (m_CarController.transform.position.y < GameManager.Instance.m_RespawnLevel)
        {
            Respawn();
        }
    }
}
