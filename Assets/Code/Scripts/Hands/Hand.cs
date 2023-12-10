using UnityEngine;

public enum HandType
{
    LeftHand,
    RightHand
}

public class Hand : MonoBehaviour
{
    public HandType type;
    public float triggerValue;
    public float gripValue;
}