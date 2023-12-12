using UnityEngine;

public class CartonRotation : MonoBehaviour
{
    void Update()
    {
        RotateCarton();
    }

    void RotateCarton()
    {
        transform.Rotate(new Vector3(40f, 40f, 0f) * Time.deltaTime);
    }
}