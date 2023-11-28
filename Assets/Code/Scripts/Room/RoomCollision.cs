using System.Collections;
using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        MoneyManager.totalMoney--;

        Product product = obj.GetComponent<Product>();
        ProductsManager.Products.Remove(product);

        StartCoroutine(WaitToDestroyObject(obj));
    }

    IEnumerator WaitToDestroyObject(Collider obj)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj.gameObject);
    }
}