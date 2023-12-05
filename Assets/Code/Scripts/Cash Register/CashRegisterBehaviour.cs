using UnityEngine;

public class CashRegisterBehaviour : MonoBehaviour
{
    public static bool isCashRegisterOn;
    [SerializeField] GameObject powerLight;
    Material powerLightMaterial;
    Color onColor = new(0f, 0.502f, 0f);
    Color offColor = new(1f, 0f, 0f);

    void Awake()
    {
        isCashRegisterOn = false;
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
}