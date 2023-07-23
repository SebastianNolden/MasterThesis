using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessAndMaterialManager : MonoBehaviour
{
    // brightness material
    [SerializeField] Material normalBrightness;
    [SerializeField] Material darkerBrightness;
    [SerializeField] Material darkestBrightness;

    // wood & Polystryrene material
    [SerializeField] Material metalMatS;
    [SerializeField] Material metalMatB;
    [SerializeField] Material woodMat;
    [SerializeField] Material polyMat;

    [SerializeField] WeightMaterialController smallL;
    [SerializeField] WeightMaterialController normalL;
    [SerializeField] WeightMaterialController bigL;

    [SerializeField] WeightMaterialController smallR;
    [SerializeField] WeightMaterialController normalR;
    [SerializeField] WeightMaterialController bigR;

    [ContextMenu("ResetHandle")]
    public void ResetHandle() {
        SetMaterialsOnObjects(metalMatS, metalMatB, metalMatS, metalMatB);
    }

    // Brightness functions
    [ContextMenu("SetDarkerandNormal")]
    public void SetDarkerandNormal() {
        SetMaterialsOnObjects(darkerBrightness, normalBrightness);
    }

    [ContextMenu("SetNormalandDarkest")]
    public void SetNormalandDarkest() {
        SetMaterialsOnObjects(normalBrightness, darkestBrightness);
    }

    [ContextMenu("SetDarkerandDarkest")]
    public void SetDarkerandDarkest() {
        SetMaterialsOnObjects(darkerBrightness, darkestBrightness);
    }

    [ContextMenu("SetNormalandDarker")]
    public void SetNormalandDarker() {
        SetMaterialsOnObjects(normalBrightness, darkerBrightness);
    }

    [ContextMenu("SetDarkestandDarker")]
    public void SetDarkestandDarker() {
        SetMaterialsOnObjects(darkestBrightness, darkerBrightness);
    }

    [ContextMenu("SetDarkestandNormal")]
    public void SetDarkestandNormal() {
        SetMaterialsOnObjects(darkestBrightness, normalBrightness);
    }

    // Material Functions
    [ContextMenu("SetNormalandWood")]
    public void SetNormalandWood() {
        SetMaterialsOnObjects(metalMatS, metalMatB, woodMat, woodMat);
    }

    [ContextMenu("SetWoodandPoly")]
    public void SetWoodandPoly() {
        SetMaterialsOnObjects(woodMat, polyMat);
    }

    [ContextMenu("SetPolyandNormal")]
    public void SetPolyandNormal() {
        SetMaterialsOnObjects(polyMat, polyMat, metalMatS, metalMatB);
    }

    [ContextMenu("SetWoodandNormal")]
    public void SetWoodandNormal() {
        SetMaterialsOnObjects(woodMat, woodMat, metalMatS, metalMatB);
    }

    [ContextMenu("SetPolyandWood")]
    public void SetPolyandWood() {
        SetMaterialsOnObjects(polyMat, woodMat);
    }

    [ContextMenu("SetNormalandPoly")]
    public void SetNormalandPoly() {
        SetMaterialsOnObjects(metalMatS, metalMatB, polyMat, polyMat);
    }

    private void SetMaterialsOnObjects(Material leftS, Material leftB, Material rightS, Material rightB) {
        smallL.SetMaterial(leftS, leftB, rightS, rightB);
        normalL.SetMaterial(leftS, leftB, rightS, rightB);
        bigL.SetMaterial(leftS, leftB, rightS, rightB);

        smallR.SetMaterial(leftS, leftB, rightS, rightB);
        normalR.SetMaterial(leftS, leftB, rightS, rightB);
        bigR.SetMaterial(leftS, leftB, rightS, rightB);
    }

    private void SetMaterialsOnObjects(Material left, Material right) {
        smallL.SetMaterial(left, right);
        normalL.SetMaterial(left, right);
        bigL.SetMaterial(left, right);

        smallR.SetMaterial(left, right);
        normalR.SetMaterial(left, right);
        bigR.SetMaterial(left, right);
    }
}
