using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public GameObject timer, collected1, collected2, collected3, collected4, glass;

    public Player p;
    public Customer c;

    bool isTimerActive;

    public float score;
    public float timerCount;

    void Start ()
    {
        score = 1000f;
    }
	
	void Update ()
    {
        //Debug.Log("timerCount: " + timerCount + " isTimeActive: " + isTimerActive);

        if (isTimerActive)
            ChangeScore();
    }

    public void SetTimer (bool value)
    {
        isTimerActive = value;
    }

    public void ChangeScore ()
    {
        score -= timerCount;

        if (score < 0f)
        {
            TimesUp();
            score = 1f;
        }

        timer.GetComponent<TextMesh>().text = score.ToString("#");
    }

    public void SetCounterSpeed(float value)
    {
        timerCount = value;
    }

    public void SetCollected(float[] counterArray)
    {
        float value = 0;
        
        // Sum all variables in array.
        if (counterArray[9] == 0)
        {
            for (int i = 0; i < counterArray.Length; i++)
                value += counterArray[i];

            try {
                if (value <= 0)
                    collected1.GetComponent<TextMesh>().text = "0";
                else
                    collected1.GetComponent<TextMesh>().text = value.ToString("#");
                // Change color to red when to much fruit.
                if (value > 99f)
                {
                    value -= 99f;
                    collected1.GetComponent<TextMesh>().text = value.ToString("#");
                    collected1.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
                }
            } catch (UnassignedReferenceException) {

            }
        }
        // Keep variables in array separated.
        else if (counterArray[9] == 1)
        {
            try {
                if (counterArray[0] <= 0)
                    collected1.GetComponent<TextMesh>().text = "0";
                else
                    collected1.GetComponent<TextMesh>().text = counterArray[0].ToString("0.#");
                // Change color to red when to much fruit.
                if (counterArray[0] > 99f)
                {
                    counterArray[0] -= 99f;
                    collected1.GetComponent<TextMesh>().text = counterArray[0].ToString("0.#");
                    collected1.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
                }
            } catch (UnassignedReferenceException) {

            }
            try {
                if (counterArray[1] <= 0)
                    collected2.GetComponent<TextMesh>().text = "0";
                else
                    collected2.GetComponent<TextMesh>().text = counterArray[1].ToString("0.#");
                // Change color to red when to much fruit.
                if (counterArray[1] > 99f)
                {
                    counterArray[1] -= 99f;
                    collected2.GetComponent<TextMesh>().text = counterArray[1].ToString("0.#");
                    collected2.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
                }
            } catch (UnassignedReferenceException) {

            }
            try {
                if (counterArray[2] <= 0)
                    collected3.GetComponent<TextMesh>().text = "0";
                else
                    collected3.GetComponent<TextMesh>().text = counterArray[2].ToString("0.#");
                // Change color to red when to much fruit.
                if (counterArray[2] > 99f)
                {
                    counterArray[2] -= 99f;
                    collected3.GetComponent<TextMesh>().text = counterArray[2].ToString("0.#");
                    collected3.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
                }
            } catch (UnassignedReferenceException) {

            }
            try {
                if (counterArray[3] <= 0)
                    collected4.GetComponent<TextMesh>().text = "0";
                else
                    collected4.GetComponent<TextMesh>().text = counterArray[3].ToString("0.#");
                // Change color to red when to much fruit.
                if (counterArray[3] > 99f)
                {
                    counterArray[3] -= 99f;
                    collected4.GetComponent<TextMesh>().text = counterArray[3].ToString("0.#");
                    collected4.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
                }
            } catch (UnassignedReferenceException) {

            }
        }
    }

    public void SetGlassCollected(float value)
    {
        try {

            if (value <= 0)
                glass.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);
            else
                glass.GetComponent<TextMesh>().color = new Color32(178, 255, 0, 255);
        }
        catch (UnassignedReferenceException) {
            
        }
    }

    private void TimesUp ()
    {
        // Stop timer.
        SetTimer(false);
        // Start customer handle.
        c.Action("Time");
        p.SetPlayerIsSad();
        p.SetLevelFinished(true);
    }
}
