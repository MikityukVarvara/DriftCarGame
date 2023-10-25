using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentBreakFroce;
    private bool isBreaking;

    //Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    //Wheel Colliders
    [SerializeField] private WheelCollider FL_WheelCollider, FR_WheelCollider;
    [SerializeField] private WheelCollider RL_WheelCollider, RR_WheelCollider;

    //Wheels
    [SerializeField] private Transform FL_WheelTransform, FR_WheelTransform;
    [SerializeField] private Transform RL_WheelTransform, RR_WheelTransform;

    private void FixedUpdate()
    {
        GetInput();// Get player input (control keys)
        HandleMotor();// Control of engine and brake forces
        HandleSteering();// Steering control
        UpdateWheels();// Update the graphic display of the wheels
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        FL_WheelCollider.motorTorque = verticalInput * motorForce;
        FR_WheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakFroce = isBreaking ? currentBreakFroce : 0f; // Setting the brake force depending on pressing the spacebar
        ApplyBreaking();// Apply brake
    }
    private void ApplyBreaking()
    {
        FR_WheelCollider.brakeTorque = currentBreakFroce;// Application of brake force to the front wheels
        FL_WheelCollider.brakeTorque = currentBreakFroce;

        RL_WheelCollider.brakeTorque = currentBreakFroce;// Application of brake force to the rear wheels
        RR_WheelCollider.brakeTorque = currentBreakFroce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;// Determination of the angle of rotation of the steering wheel
        FL_WheelCollider.steerAngle = currentSteerAngle; // Application of the angle of rotation to the front wheels
        FR_WheelCollider.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(FL_WheelCollider, FL_WheelTransform);// Update the graphic display of the front wheels
        UpdateSingleWheel(FR_WheelCollider, FR_WheelTransform);
        UpdateSingleWheel(RR_WheelCollider, RR_WheelTransform);// Update the graphic display of the back wheels
        UpdateSingleWheel(RL_WheelCollider, RL_WheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);// Obtaining the position and rotation of the wheel in world space
        wheelTransform.rotation = rot;// Update the rotation of the graphical representation of the wheel
        wheelTransform.position = pos;// Update the position of the graphical representation of the wheel
    }

}
