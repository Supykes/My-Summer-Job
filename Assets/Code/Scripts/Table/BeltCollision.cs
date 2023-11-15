using System.Collections.Generic;
using UnityEngine;

public class BeltCollision : MonoBehaviour
{
    float speed = 0.08f;
    List<Transform> colliders = new();

    void OnTriggerEnter(Collider collider)
    {
        colliders.Add(collider.transform);
    }

    void OnTriggerExit(Collider collider)
    {
        colliders.Remove(collider.transform);
    }

    void Update()
    {
        MoveColliders();
    }

    void MoveColliders()
    {
        foreach (Transform collider in colliders)
        {
            collider.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}