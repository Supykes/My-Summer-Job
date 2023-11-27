using System.Collections;
using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        MoneyManager.totalMoney--;

        StartCoroutine(WaitToDestroyObject(obj));
    }

    IEnumerator WaitToDestroyObject(Collider obj)
    {
        yield return new WaitForSeconds(1f);

        Destroy(obj);
    }
}