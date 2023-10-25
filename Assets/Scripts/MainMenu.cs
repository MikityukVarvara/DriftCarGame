using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load scene Garage for tuning
   public void GarageButton()
    {
        SceneManager.LoadScene("Garage");// Method to load the "Garage" scene when the "Garage" button is clicked in the main menu
    }


    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");// Method to load the "Level1" scene when the "Play" button is pressed in the main menu
    }
}
