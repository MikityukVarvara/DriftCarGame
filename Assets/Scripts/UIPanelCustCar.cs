using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelCustCar : MonoBehaviour
{
    public CarController controller;
    public CustCar CustCar;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<CarController>(); // Change FindObjectOfType 'cause deprecated
        CustCar = controller.GetComponent<CustCar>();   
    }

    public void SetColorRed()
    {
        CustCar.setColor(Color.red);
    }

    public void SetColorBlue()
    {
        CustCar.setColor(Color.blue);
    }

    public void SetColorYellow()
    {
        CustCar.setColor(Color.yellow);
    }



}
