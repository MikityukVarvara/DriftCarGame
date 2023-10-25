using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustCar : MonoBehaviour
{
    public Material bodyCarColor;
   
    //Method set body color for car
    public void setColor(Color C)
    {
        bodyCarColor.color = C;
    }
}
