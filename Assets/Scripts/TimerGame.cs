using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimerGame : MonoBehaviour
{
    public GameObject endLevelPanel;
    public DriftManagerScore driftManagerScore;

    public TMP_Text totalScoreText;// Text to display the total number of points
    public TMP_Text totalCashText;// Text to display the total amount of cash

    private int timer = 120; // 2 minutes 
   
    private void Start()
    {
        endLevelPanel.SetActive(false);
        StartCoroutine(CountDownToEnd());     
    }

    // Coroutine to count down the time until the end of the game
    IEnumerator CountDownToEnd()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;         
        }

        // Update texts with points and cash from another component
        totalScoreText.text = driftManagerScore.totalScoreText.text;
        totalCashText.text = "Cash:" + (Convert.ToInt32(driftManagerScore.totalScore) * 2).ToString();

        endLevelPanel.SetActive(true); // Show the endgame panel
    }
    
}
