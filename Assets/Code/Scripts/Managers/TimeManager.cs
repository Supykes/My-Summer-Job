using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverCanvas;
    float totalTime = 650f;
    public static bool stopTime;
    GameObject productsSpawner;
    GameObject moneyText;
    GameObject leftController;
    GameObject rightController;
    GameObject managers;

    void Awake()
    {
        stopTime = false;
    }

    void Start()
    {
        productsSpawner = GameObject.Find("Products Spawner");
        moneyText = GameObject.Find("Money Text");
        leftController = GameObject.Find("Left Controller");
        rightController = GameObject.Find("Right Controller");
        managers = GameObject.Find("Managers");
        gameOverCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    void Update()
    {
        if (!stopTime)
        {
            CountdownTime();
        }
        else
        {
            EndGame();
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

        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    void EndGame()
    {
        timeText.color = new(1f, 0f, 0f);
        productsSpawner.GetComponent<ProductsSpawner>().CancelInvoke();
        moneyText.SetActive(false);
        leftController.GetComponent<XRDirectInteractor>().enabled = false;
        rightController.GetComponent<XRDirectInteractor>().enabled = false;
        managers.GetComponent<RandomEventsManager>().enabled = false;
        gameOverCanvas.SetActive(true);
    }
}