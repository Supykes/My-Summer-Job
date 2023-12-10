using UnityEngine;

public enum ButtonType
{
    Number,
    Cancel,
    Submit,
    Power
}

public class Button : MonoBehaviour
{
    public ButtonType type;
    public string number;
}