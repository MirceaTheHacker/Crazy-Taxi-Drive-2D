using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public GameObject m_Character;
    public GameObject m_CoinMagnet;

    internal Vector2 m_CheckPoint;
    internal HealthManager m_HealthManager;
    internal CarController m_CarController { get { return GetComponentInChildren<CarController>(); } }
    internal CarSoundFX m_CarSoundFX { get { return GetComponentInChildren<CarSoundFX>(); } }
    internal Coroutine m_OutOfFuelCoroutine = null;


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

    internal IEnumerator Respawn()
    {
        DamagePlayer(1);
        if (m_HealthManager.curHealth > 0)
        {
            yield return StartCoroutine(GetGoodSpawnZone());
            m_CarController.transform.position = m_CheckPoint;
            m_CarController.transform.rotation = Quaternion.identity;
            CancelVellocity();
            m_CarController.AddFuel(1);
            GameManager.Instance.m_SoundManager.PlayGameOverSound();
        }
        else
        {
            DeathHandler();
        }
    }

    private bool SpawnZoneGood()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(m_CheckPoint, new Vector2(1, 1), 0, Vector2.down, 1);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator GetGoodSpawnZone()
    {
        while (!SpawnZoneGood())
        {
            Debug.Log("Loocking for a better spot...");
            m_CheckPoint.y += 1;
            yield return new WaitForEndOfFrame();
        }
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
        m_HealthManager.UpdateHearts(damageValue);
    }

    private void DeathHandler()
    {
        if (isAlive)
        {
            isAlive = false;
            m_CarController.enabled = false;
            StartCoroutine(GameManager.Instance.GameOverHandler());
        }

    }


    internal IEnumerator OutOfFuelCoroutine()
    {
        StopCar();
        float direction = m_CarController.m_Rigidbody2d.velocity.x;
        while (m_CarController.m_Rigidbody2d.velocity.x * direction > 0)
        {
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(3);
        if (m_CarController.m_Fuel < 0)
        {
            StartCoroutine(Respawn());
        }
    }

    internal void StopCar()
    {
        m_CarController.CutMovement();
        m_CarController.backwheel.useMotor = false;
        m_CarController.frontwheel.useMotor = false;
    }

    internal void DisableCarScripts()
    {
        m_CarController.enabled = false;
        m_CarSoundFX.enabled = false;
        m_Character.SetActive(false);
        m_CoinMagnet.SetActive(false);
        if (m_OutOfFuelCoroutine != null)
        {
            StopCoroutine(m_OutOfFuelCoroutine);
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
