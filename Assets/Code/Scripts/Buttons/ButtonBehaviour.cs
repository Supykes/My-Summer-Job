using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using TMPro;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text screenText;
    static string enteredCode;
    int codeLength = 6;

    void Awake()
    {
        enteredCode = "";
    }

    public void ModifyScreenText(HoverEnterEventArgs args)
    {
        Button button = args.interactableObject.transform.GetComponent<Button>();

        if (CashRegisterBehaviour.isCashRegisterOn)
        {
            if (button.type.Equals(ButtonType.Number) && enteredCode.Length < codeLength)
            {
                enteredCode += button.number;

                screenText.text = enteredCode;
            }
            else if (button.type.Equals(ButtonType.Cancel))
            {
                enteredCode = "";

                screenText.text = enteredCode;
            }
            else if (button.type.Equals(ButtonType.Submit) && enteredCode.Length == codeLength)
            {
                CheckEnteredCode();

                enteredCode = "";

                screenText.text = enteredCode;
            }
            else if (button.type.Equals(ButtonType.Power))
            {
                enteredCode = "";

                CashRegisterBehaviour.startedOnce = false;

                CashRegisterBehaviour.TurnOffCashRegister(screenText);
            }
        }
        else
        {
            if (button.type.Equals(ButtonType.Power) && !CashRegisterBehaviour.startedOnce)
            {
                CashRegisterBehaviour.startedOnce = true;

                screenText.text = "Please wait...";

                StartCoroutine(WaitToTurnOnCashRegister(5f));
            }
        }
    }

    void CheckEnteredCode()
    {
        foreach (Product product in ProductsManager.Products)
        {
            if (product.code.Equals(enteredCode))
            {
                product.isCodeEntered = true;
            }
        }
    }

    IEnumerator WaitToTurnOnCashRegister(float time)
    {
        yield return new WaitForSeconds(time);

        CashRegisterBehaviour.TurnOnCashRegister(screenText);
    }
}