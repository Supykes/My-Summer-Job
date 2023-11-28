using UnityEngine;
using TMPro;

public class Product : MonoBehaviour
{
    public bool isDamaged;
    public string code;
    public bool isCodeEntered;
    int codeLength = 6;

    void Start()
    {
        GenerateCode();
        ShowCode();
    }

    void GenerateCode()
    {
        code = "";

        for (int i = 0; i < codeLength; i++)
        {
            int randomNumber = Random.Range(0, 10);

            code += randomNumber;
        }

        foreach (Product product in ProductsManager.Products)
        {
            if (product.code.Equals(code))
            {
                GenerateCode();
            }
            else
            {
                ProductsManager.Products.Add(this);
            }
        }
    }

    void ShowCode()
    {
        int randomCanvasIndex = Random.Range(0, transform.childCount);
        Transform canvas = transform.GetChild(randomCanvasIndex);

        int randomTextIndex = Random.Range(0, canvas.childCount);
        GameObject codeText = canvas.GetChild(randomTextIndex).gameObject;

        codeText.GetComponent<TMP_Text>().text = code;
        codeText.SetActive(true);
    }
}