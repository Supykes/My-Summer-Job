using UnityEngine;
using TMPro;

public class RandomEventsManager : MonoBehaviour
{
    [SerializeField] TMP_Text screenText;
    float totalTime = 55f;
    int randomIndex;

    void Update()
    {
        CountdownTime();
    }

    void CountdownTime()
    {
        totalTime -= Time.deltaTime;

        int seconds = Mathf.RoundToInt(totalTime % 60f);
        if (seconds == 0)
        {
            totalTime = 16f;

            GenerateRandomIndex();
            ExecuteRandomEvent();
        }
    }

    void GenerateRandomIndex()
    {
        randomIndex = Random.Range(0, 3);
    }

    void ExecuteRandomEvent()
    {
        switch (randomIndex)
        {
            case 0:
                break;
            case 1:
                ButtonBehaviour.enteredCode = "";

                CashRegisterBehaviour.startedOnce = false;

                CashRegisterBehaviour.TurnOffCashRegister(screenText);

                break;
            case 2:
                ConveyorBehaviour.TurnOffConveyor();

                break;
        }
    }
}