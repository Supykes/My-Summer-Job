using UnityEngine;
using UnityEngine.InputSystem;

public class HandsAnimation : MonoBehaviour
{
    [SerializeField] Animator handAnimator;
    [SerializeField] InputActionProperty pinchAnimationAction;
    [SerializeField] InputActionProperty gripAnimationAction;

    void Update()
    {
        AnimateHand();
    }

    void AnimateHand()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        float gripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerValue);
        handAnimator.SetFloat("Grip", gripValue);
    }
}