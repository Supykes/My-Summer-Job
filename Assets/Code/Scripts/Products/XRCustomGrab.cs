using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class XRCustomGrab : XRGrabInteractable
{
    Vector3 interactorPosition = Vector3.zero;
    Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        StoreInteractor(args.interactor);
        MatchAttachPoints(args.interactor);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);

        ResetAttachPoint(args.interactor);
        ClearInteractor();
    }

    void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    void ClearInteractor()
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }

    void MatchAttachPoints(XRBaseInteractor interactor)
    {
        bool hasAttachPoint = attachTransform != null;

        interactor.attachTransform.position = hasAttachPoint ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttachPoint ? attachTransform.rotation : transform.rotation;
    }

    void ResetAttachPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }
}