using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform car;// Link to the car transform we will follow
    private Rigidbody carRB;// A reference to the vehicle's Rigidbody component to obtain information about its motion
    public Vector3 offset;// The position the camera should be moved to from the car
    public float speed;// Camera movement speed

    private void Start()
    {
        carRB = car.GetComponent<Rigidbody>(); // We get the Rigidbody component of the car
    }

    private void LateUpdate()
    {
        Vector3 carForward = (carRB.velocity + car.transform.forward).normalized;// Calculation of the vector of the direction of movement of the car

        // Smoothly move the camera position to the car position, taking into account the offset and a certain distance behind the car
        transform.position = Vector3.Lerp(transform.position, car.position + car.transform.TransformVector(offset) + carForward * (-10f), speed * Time.deltaTime);

        transform.LookAt(car);// Adjust the direction of the camera so that it looks at the car

    }
}
