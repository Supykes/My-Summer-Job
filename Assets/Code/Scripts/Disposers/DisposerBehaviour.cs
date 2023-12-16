using System.Collections;
using UnityEngine;

public enum DisposerType
{
    QualityDisposer,
    DamagedDisposer
}

public class DisposerBehaviour : MonoBehaviour
{
    [SerializeField] DisposerType disposerType;

    void OnTriggerEnter(Collider obj)
    {
        if (!obj.CompareTag("TutorialNote"))
        {
            Product product = obj.GetComponent<Product>();

            if (disposerType.Equals(DisposerType.QualityDisposer))
            {
                if (!product.isDamaged)
                {
                    if (product.isCodeEntered)
                    {
                        MoneyManager.totalMoney++;
                    }
                    else
                    {
                        MoneyManager.totalMoney--;
                    }
                }
                else
                {
                    MoneyManager.totalMoney--;
                }
            }
            else if (disposerType.Equals(DisposerType.DamagedDisposer))
            {
                if (product.isDamaged)
                {
                    MoneyManager.totalMoney++;
                }
                else
                {
                    MoneyManager.totalMoney--;
                }
            }

            ProductsManager.Products.Remove(product);
        }

        StartCoroutine(WaitToDestroyObject(obj));
    }

    IEnumerator WaitToDestroyObject(Collider obj)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj.gameObject);
    }
}