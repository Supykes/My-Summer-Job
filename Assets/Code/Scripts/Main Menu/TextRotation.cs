using UnityEngine;

public class TextRotation : MonoBehaviour
{
    void Update()
    {
        RotateText();
    }

    void RotateText()
    {
        transform.Rotate(new Vector3(0f, 40f, 0f) * Time.deltaTime);
    }
}