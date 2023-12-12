using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text payText;
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

            payText.text = $"<color=#008000>Today's pay: <u>{totalMoney} $</u><br>Good job! You have money for some bread today! (Or not...)</color>";
        }
        else
        {
            moneyText.color = negativeColor;

            payText.text = $"<color=#008000>Today's pay: </color><color=#FF0000><u>{totalMoney} $</u><br>Ouch... That's rough. Better luck next day!</color>";
        }

        moneyText.text = $"{totalMoney} $";
    }
}