using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class VRController : XRController {    
    float weight = 1f;


    protected override void UpdateTrackingInput(XRControllerState controllerState) {
        //base.UpdateTrackingInput(controllerState);
        if (controllerState == null)
            return;

        controllerState.inputTrackingState = InputTrackingState.None;

            
        if (inputDevice.TryGetFeatureValue(CommonUsages.trackingState, out var trackingState)) {
            controllerState.inputTrackingState = trackingState;

            if ((trackingState & InputTrackingState.Position) != 0 &&
                inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out var devicePosition)) {

                Vector3 newPosition = new Vector3(devicePosition.x, devicePosition.y * weight, devicePosition.z);
                controllerState.position = newPosition;
            }

            if ((trackingState & InputTrackingState.Rotation) != 0 &&
                inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out var deviceRotation)) {
                controllerState.rotation = deviceRotation;
            }
            
        }
    }

    public void SetWeight(float newWeight) {
        weight = newWeight;
    }

    public void ResetWeight() {
        weight = 1f;
    }
}
