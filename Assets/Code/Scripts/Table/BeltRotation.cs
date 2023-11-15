using UnityEngine;

public class BeltRotation : MonoBehaviour
{
    void Update()
    {
        RotateBelt();
    }

    void RotateBelt()
    {
        transform.Rotate(new Vector3(0f, -40f, 0f) * Time.deltaTime);
    }
}