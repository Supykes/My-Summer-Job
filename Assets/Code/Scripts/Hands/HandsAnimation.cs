using UnityEngine;
using UnityEngine.InputSystem;

public class HandsAnimation : MonoBehaviour
{
    [SerializeField] Animator handAnimator;
    [SerializeField] InputActionProperty pointAnimationAction;
    [SerializeField] InputActionProperty gripAnimationAction;

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
    }
}