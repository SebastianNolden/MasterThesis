using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDRatioManager : MonoBehaviour
{
    [SerializeField] VRController rightHand;
    [SerializeField] VRController leftHand;

    [SerializeField] float lightweight = 1.2f;
    [SerializeField] float normal = 1f;
    [SerializeField] float heavy = 0.8f;

    public void ResetHandle() {
        rightHand.ResetWeight();
        leftHand.ResetWeight();
    }

    public void SetLightWeight() {
        rightHand.SetWeight(lightweight);
        leftHand.SetWeight(lightweight);
    }

    public void SetHeavyWeight() {
        rightHand.SetWeight(heavy);
        leftHand.SetWeight(heavy);
    }

    public void SetNormalWeight() {
        rightHand.SetWeight(normal);
        leftHand.SetWeight(normal);
    }
}
