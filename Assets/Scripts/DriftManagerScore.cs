using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class DriftManagerScore : MonoBehaviour
{
    // Public fields for communication with other Unity objects
    public Rigidbody carRB;
    public TMP_Text totalScoreText;
    public TMP_Text currentScoreText;
    public TMP_Text factorText;
    public TMP_Text driftAngleText;

    // Variables to calculate and track drift and points
    private float speed = 0;
    private float driftAngle = 0;
    private float driftFactor = 1;
    private float currentScore;
    internal float totalScore;

    // Drift options and UI settings
    private bool isDrifting = false;

    public float minimumSpeed = 5;
    public float minimumAngle = 10;
    public float driftingDelay = 0.2f;
    public GameObject driftingObject;
    public Color normalDriftColor;
    public Color nearStopColor;
    public Color driftEndedColor;

    private IEnumerator stopDriftingCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        driftingObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ManageDrift();
        ManageUI();
    }
    // Method to track car drift
    void ManageDrift()
    {
        // Calculate the drift speed and angle
        speed = carRB.velocity.magnitude;
        driftAngle = Vector3.Angle(carRB.transform.forward, (carRB.velocity + carRB.transform.forward).normalized);

        // Check for minimum angle and minimum speed for drift
        if (driftAngle > 120)
        {
            driftAngle = 0;
        }
        if (driftAngle >= minimumAngle && speed > minimumSpeed)
        {
            if (!isDrifting || stopDriftingCoroutine != null)
            {
                StartDrift();
            }
        }
        else
        {
            if (isDrifting && stopDriftingCoroutine == null)
            {
                StopDrift();
            }
        }
        if (isDrifting)
        {
            // Calculate points for drift
            currentScore += Time.deltaTime * driftAngle * driftFactor;
            driftFactor += Time.deltaTime;
            driftingObject.SetActive(true);
          
        }
    }

    // Asynchronous method to start the drift
    async void StartDrift()
    {
        if (!isDrifting)
        {
            // Delay before drift starts
            await Task.Delay(Mathf.RoundToInt(1000 * driftingDelay));
            driftFactor = 1;
        }
        if (stopDriftingCoroutine != null)
        {
            StopCoroutine(stopDriftingCoroutine);
            stopDriftingCoroutine = null;
        }
        currentScoreText.color = normalDriftColor;
        isDrifting = true;
    }

    // Method to end the drift
    void StopDrift()
    {
        stopDriftingCoroutine = StoppingDrift();
        StartCoroutine(stopDriftingCoroutine);
    }

    // Coroutine for smooth ending of the drift
    private IEnumerator StoppingDrift()
    {
        yield return new WaitForSeconds(0.1f);
       currentScoreText.color = nearStopColor;

        yield return new WaitForSeconds(driftingDelay * 4f);
        totalScore += currentScore;
        isDrifting = false;
        currentScoreText.color = driftEndedColor;

        yield return new WaitForSeconds(0.5f);
        currentScore = 0;
        driftingObject.SetActive(false);
    }

    // Method to update the interface
    void ManageUI()
    {
        totalScoreText.text = "Total: " + (totalScore).ToString("###,###,000");
        factorText.text = driftFactor.ToString("###,###,##0.0") + "X";
        currentScoreText.text = currentScore.ToString("###,###,000");
        driftAngleText.text = driftAngle.ToString("###,##0") + "°";
    }
    
}
