using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isLeftHandPointing;
    public static bool isRightHandPointing;
    [SerializeField] GameObject leftHandGameObject;
    [SerializeField] GameObject rightHandGameObject;
    Hand leftHand;
    SphereCollider leftHandSphereCollider;
    BoxCollider leftHandBoxCollider;
    Hand rightHand;
    SphereCollider rightHandSphereCollider;
    BoxCollider rightHandBoxCollider;

    void Awake()
    {
        isLeftHandPointing = false;
        isRightHandPointing = false;
    }

    void Start()
    {
        leftHand = leftHandGameObject.GetComponent<Hand>();
        leftHandSphereCollider = leftHandGameObject.GetComponent<SphereCollider>();
        leftHandBoxCollider = leftHandGameObject.GetComponent<BoxCollider>();
        rightHand = rightHandGameObject.GetComponent<Hand>();
        rightHandSphereCollider = rightHandGameObject.GetComponent<SphereCollider>();
        rightHandBoxCollider = rightHandGameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        CheckHandsPointingStatus();

        ControlHandsColliders();
    }

    void CheckHandsPointingStatus()
    {
        if (leftHand.triggerValue == 1f && leftHand.gripValue == 0f)
        {
            isLeftHandPointing = true;
        }
        else
        {
            isLeftHandPointing = false;
        }

        if (rightHand.triggerValue == 1f && rightHand.gripValue == 0f)
        {
            isRightHandPointing = true;
        }
        else
        {
            isRightHandPointing = false;
        }
    }

    void ControlHandsColliders()
    {
        if (isLeftHandPointing)
        {
            leftHandSphereCollider.enabled = false;
            leftHandBoxCollider.enabled = true;
        }
        else
        {
            leftHandSphereCollider.enabled = true;
            leftHandBoxCollider.enabled = false;
        }

        if (isRightHandPointing)
        {
            rightHandSphereCollider.enabled = false;
            rightHandBoxCollider.enabled = true;
        }
        else
        {
            rightHandSphereCollider.enabled = true;
            rightHandBoxCollider.enabled = false;
        }
    }
}