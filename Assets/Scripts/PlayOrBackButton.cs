using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayorBackButton : MonoBehaviour
{
   public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");// Method that loads the "MainMenu" scene when the "Back to Menu" button is clicked
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");// Method that loads the "Level1" scene when the "Play" button is clicked
    }
}
