using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputActionProperty primaryButtonAction;

    void Awake()
    {
        primaryButtonAction.action.performed += RestartGame;
    }

    public void StartGame(HoverEnterEventArgs args)
    {
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();

        if ((hand.type.Equals(HandType.LeftHand) && PlayerManager.isLeftHandPointing) ||
            (hand.type.Equals(HandType.RightHand) && PlayerManager.isRightHandPointing))
        {
            SceneManager.LoadScene("Main Scene");
        }
    }

    void RestartGame(InputAction.CallbackContext context)
    {
        if (TimeManager.stopTime)
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
}