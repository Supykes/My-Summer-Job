using UnityEngine;
using TMPro;

public class RandomEventsManager : MonoBehaviour
{
    [Header("Screen Text")]
    [SerializeField] TMP_Text screenText;

    [Header("Random Event Sparks")]
    [SerializeField] GameObject sparksSystem;

    [Header("Sparks Transform")]
    [SerializeField] Transform cashRegisterSparksTransform;
    [SerializeField] Transform conveyorSparksTransform;

    float totalTime = 65f;
    int randomIndex;

    void Update()
    {
        CountdownTime();
    }

    void CountdownTime()
    {
        totalTime -= Time.deltaTime;

        int seconds = Mathf.RoundToInt(totalTime);
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
                if (CashRegisterBehaviour.isCashRegisterOn)
                {
                    ButtonBehaviour.enteredCode = "";

                    CashRegisterBehaviour.startedOnce = false;

                    CashRegisterBehaviour.TurnOffCashRegister(screenText);

                    PlaySparks(cashRegisterSparksTransform);
                }

                break;
            case 2:
                if (ConveyorBehaviour.isConveyorOn)
                {
                    ConveyorBehaviour.TurnOffConveyor();

                    PlaySparks(conveyorSparksTransform);
                }

                break;
        }
    }

    void PlaySparks(Transform spawnTransform)
    {
        Quaternion sparksRotation = sparksSystem.transform.rotation;

        GameObject sparks = Instantiate(sparksSystem, spawnTransform.position, sparksRotation);

        sparks.GetComponent<ParticleSystem>().Play();
    }
}