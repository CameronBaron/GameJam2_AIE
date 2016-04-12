using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{

    public Text minuteText;
    public Text secondText;
    public float timeOfGame = 300.0f;
    bool stopTime = false;

    // Update is called once per frame
	void Update ()
    {
        if (stopTime == false)
        {
            timeOfGame -= Time.deltaTime;

            float minutes = Mathf.Floor(timeOfGame / 60);
            float seconds = timeOfGame % 60;

            if (minutes < 0 && seconds <= 0)
            {
                stopTime = true;
                minutes = 0;
                seconds = 0;
                Time.timeScale = 0;
            }

            Debug.Log("Minutes: " + minutes);
            Debug.Log("Seconds: " + seconds);

            minuteText.text = minutes + ": ";
            secondText.text = "" + seconds.ToString("00");
        }        
	}
}
