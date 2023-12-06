using UnityEngine;
using TMPro;

public class CashRegisterBehaviour : MonoBehaviour
{
    public static bool isCashRegisterOn;
    public static bool startedOnce;
    [SerializeField] GameObject powerLight;
    Material powerLightMaterial;
    Color onColor = new(0f, 0.502f, 0f);
    Color offColor = new(1f, 0f, 0f);

    void Awake()
    {
        isCashRegisterOn = false;
        startedOnce = false;
    }

    void Start()
    {
        powerLightMaterial = powerLight.GetComponent<Renderer>().material;
    }

    void Update()
    {
        SetPowerLightColor();
    }

    void SetPowerLightColor()
    {
        if (isCashRegisterOn)
        {
            powerLightMaterial.SetColor("_Color", onColor);
            powerLightMaterial.SetColor("_EmissionColor", onColor);
        }
        else
        {
            powerLightMaterial.SetColor("_Color", offColor);
            powerLightMaterial.SetColor("_EmissionColor", offColor);
        }
    }

    public static void TurnOnCashRegister(TMP_Text screenText)
    {
        isCashRegisterOn = true;

        screenText.fontSize = 260f;
        screenText.color = new(1f, 1f, 1f);
        screenText.text = "";
    }

    public static void TurnOffCashRegister(TMP_Text screenText)
    {
        isCashRegisterOn = false;

        screenText.fontSize = 160f;
        screenText.color = new(0f, 0.502f, 0f);
        screenText.text = "";
    }
}