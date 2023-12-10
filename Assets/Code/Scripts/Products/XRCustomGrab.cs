using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class XRCustomGrab : XRGrabInteractable
{
    Vector3 interactorPosition = Vector3.zero;
    Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        StoreInteractor(args.interactorObject, args.interactableObject);
        MatchAttachPoints(args.interactorObject, args.interactableObject);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);

        ResetAttachPoint(args.interactorObject, args.interactableObject);
        ClearInteractor();
    }

    void StoreInteractor(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        interactorPosition = interactor.GetAttachTransform(interactable).localPosition;
        interactorRotation = interactor.GetAttachTransform(interactable).localRotation;
    }

    void ClearInteractor()
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }

    void MatchAttachPoints(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        bool hasAttachPoint = attachTransform != null;

        interactor.GetAttachTransform(interactable).position = hasAttachPoint ? attachTransform.position : transform.position;
        interactor.GetAttachTransform(interactable).rotation = hasAttachPoint ? attachTransform.rotation : transform.rotation;
    }

    void ResetAttachPoint(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        interactor.GetAttachTransform(interactable).localPosition = interactorPosition;
        interactor.GetAttachTransform(interactable).localRotation = interactorRotation;
    }
}