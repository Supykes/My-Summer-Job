using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    public static int totalMoney;
    Color positiveColor = new(0f, 0.502f, 0f);
    Color negativeColor = new(1f, 0f, 0f);

    void Awake()
    {
        totalMoney = 0;
    }

    void Update()
    {
        DisplayMoney();
    }

    void DisplayMoney()
    {
        if (totalMoney >= 0)
        {
            moneyText.color = positiveColor;
        }
        else
        {
            moneyText.color = negativeColor;
        }

        moneyText.text = $"{totalMoney} $";
    }
}