using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        MoneyManager.totalMoney--;

        Destroy(obj);
    }
}