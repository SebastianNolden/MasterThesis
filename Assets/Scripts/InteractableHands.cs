using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class InteractableHands : MonoBehaviour
{

    [SerializeField] XRRayInteractor xrInteractor;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] XRInteractorLineVisual xrInterActorLineVisual;

    // Start is called before the first frame update
    public void ActivateInteractableHands(bool active) {
        xrInteractor.enabled = active;
        lineRenderer.enabled = active;
        xrInterActorLineVisual.enabled = active;
    }
}
