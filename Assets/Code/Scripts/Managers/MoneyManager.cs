using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    public static int totalMoney;

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
            moneyText.color = Color.green;
        }
        else
        {
            moneyText.color = Color.red;
        }

        moneyText.text = $"Money: {totalMoney}$";
    }
}