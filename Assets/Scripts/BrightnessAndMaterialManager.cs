using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessAndMaterialManager : MonoBehaviour
{
    [SerializeField] Material normalMat;
    
    // brightness material
    [SerializeField] Material brightMat;
    [SerializeField] Material darkMat;

    // wood & Polystryrene material
    [SerializeField] Material woodMat;
    [SerializeField] Material polyMat;

    [SerializeField] Renderer leftHandleS;
    [SerializeField] Renderer leftHandleB;
    [SerializeField] Renderer rightHandleS;
    [SerializeField] Renderer rightHandleB;



    public void ResetHandle() {
        SetMaterialsOnObjects(normalMat, normalMat);
    }

    // Brightness functions
    public void SetBrightandNormal() {
        SetMaterialsOnObjects(brightMat, normalMat);
    }

    public void SetNormalandDark() {
        SetMaterialsOnObjects(normalMat, darkMat);
    }

    public void SetBrightandDark() {
        SetMaterialsOnObjects(brightMat, darkMat);
    }

    public void SetNormalandBright() {
        SetMaterialsOnObjects(normalMat, brightMat);
    }

    public void SetDarkandBright() {
        SetMaterialsOnObjects(darkMat, brightMat);
    }

    public void SetDarkandNormal() {
        SetMaterialsOnObjects(darkMat, normalMat);
    }

    // Material Functions
    public void SetNormalandWood() {
        SetMaterialsOnObjects(normalMat, woodMat);
    }

    public void SetWoodandPoly() {
        SetMaterialsOnObjects(woodMat, polyMat);
    }

    public void SetPolyandNormal() {
        SetMaterialsOnObjects(polyMat, normalMat);
    }

    public void SetWoodandNormal() {
        SetMaterialsOnObjects(woodMat, normalMat);
    }

    public void SetPolyandWood() {
        SetMaterialsOnObjects(polyMat, woodMat);
    }

    public void SetNormalandPoly() {
        SetMaterialsOnObjects(normalMat, polyMat);
    }

    private void SetMaterialsOnObjects(Material left, Material right) {
        leftHandleS.material = left;
        leftHandleB.material = left;
        rightHandleS.material = right;
        rightHandleB.material = right;
    }
}
