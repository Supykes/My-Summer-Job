using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    float totalTime = 120f;
    bool stopTime = false;

    void Update()
    {
        if (!stopTime)
        {
            CountdownTime();
        }
    }

    void CountdownTime()
    {
        totalTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.RoundToInt(totalTime % 60f);
        if (seconds == 60)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes == 0 && seconds == 0)
        {
            stopTime = true;
        }

        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}