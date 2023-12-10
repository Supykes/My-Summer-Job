using UnityEngine.InputSystem;
using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    [SerializeField] Animator handAnimator;
    [SerializeField] InputActionProperty pointAnimationAction;
    [SerializeField] InputActionProperty gripAnimationAction;
    Hand hand;

    void Start()
    {
        hand = gameObject.GetComponent<Hand>();
    }

    void Update()
    {
        AnimateHand();
    }

    void AnimateHand()
    {
        float triggerValue = pointAnimationAction.action.ReadValue<float>();
        float gripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerValue);
        handAnimator.SetFloat("Grip", gripValue);

        hand.triggerValue = triggerValue;
        hand.gripValue = gripValue;
    }
}