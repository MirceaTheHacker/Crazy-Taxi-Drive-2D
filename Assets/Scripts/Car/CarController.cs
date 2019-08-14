﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;
    public float speedF;
    public float speedB;
    public float torqueF;
    public float torqueB;
    public bool TractionFront = true;
    public bool TractionBack = true;
    //public float carRotationSpeed;
    public float fuelConsumption = 0.02f;
    public float nitroMultiplier = 2f;


    internal float m_Fuel = 1f;
    internal Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }

    private float movement;
    JointMotor2D motorFront;
    JointMotor2D motorBack;
    private float currentNitroMultiplier;
    private CarManager m_CarManager { get { return GetComponentInParent<CarManager>(); } }
    private bool m_OutOfFuel = false;

    void Update()
    {
        if (m_Fuel < 0)
        {
            if (m_OutOfFuel) return;
            m_OutOfFuel = true;
            StartCoroutine(m_CarManager.OutOfFuelCoroutine());
            return;
        }

        movement = Input.GetAxisRaw("Vertical");
        NitroCheck();

        if (movement > 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * currentNitroMultiplier * -1;
                motorFront.maxMotorTorque = torqueF;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * currentNitroMultiplier * -1;
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;

            }

        }
        else if (movement < 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * currentNitroMultiplier * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * currentNitroMultiplier * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        else
        {

            backwheel.useMotor = false;
            frontwheel.useMotor = false;

        }

        // if (Input.GetAxisRaw("Horizontal") != 0)
        // {
        //     m_Rigidbody2d.AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);
        // }
    }

    private void FixedUpdate()
    {
        m_Fuel -= fuelConsumption * Mathf.Abs(movement) * currentNitroMultiplier * Time.fixedDeltaTime;
        GameManager.Instance.m_FuelManager.m_Image.fillAmount = m_Fuel;
    }

    private void NitroCheck()
    {
        if (Input.GetKey(KeyCode.N))
        {
            currentNitroMultiplier = nitroMultiplier;
        }
        else
        {
            currentNitroMultiplier = 1f;
        }
    }

    private void OutOfFuel()
    {
        backwheel.useMotor = false;
        frontwheel.useMotor = false;
    }

    internal void AddFuel(float value)
    {
        m_Fuel += value;
        if (m_Fuel > 1)
        {
            m_Fuel = 1;
        }
        m_OutOfFuel = false;
    }

    internal void CutMovement()
    {
        movement = 0;
    }
}
