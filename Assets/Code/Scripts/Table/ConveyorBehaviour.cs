using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class ConveyorBehaviour : MonoBehaviour
{
    [SerializeField] GameObject beltCollisionTrigger;
    [SerializeField] GameObject[] belts;
    static BeltCollision beltCollision;
    static BeltRotation[] beltRotations;

    void Awake()
    {
        beltRotations = new BeltRotation[5];
    }

    void Start()
    {
        beltCollision = beltCollisionTrigger.GetComponent<BeltCollision>();
        for (int i = 0; i < belts.Length; i++)
        {
            beltRotations[i] = belts[i].GetComponent<BeltRotation>();
        }
    }

    public void TurnOnConveyor(HoverEnterEventArgs args)
    {
        Hand hand = args.interactorObject.transform.GetComponent<Hand>();

        if ((hand.type.Equals(HandType.LeftHand) && PlayerManager.isLeftHandPointing) ||
            (hand.type.Equals(HandType.RightHand) && PlayerManager.isRightHandPointing))
        {
            beltCollision.enabled = true;
            foreach (BeltRotation beltRotation in beltRotations)
            {
                beltRotation.enabled = true;
            }
        }
    }

    public static void TurnOffConveyor()
    {
        beltCollision.enabled = false;
        foreach (BeltRotation beltRotation in beltRotations)
        {
            beltRotation.enabled = false;
        }
    }
}