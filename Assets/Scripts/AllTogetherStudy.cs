using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTogetherStudy : MonoBehaviour
{
    [SerializeField] SizeManager sizeManager;
    [SerializeField] BrightnessAndMaterialManager brightAndMatManager;
    [SerializeField] CDRatioManager cdManager;

    public void SetLightWeight() {
        sizeManager.SetBigandBig();
        brightAndMatManager.SetPolyandPoly();
        cdManager.SetLightWeight();
    }

    public void SetNormalWeight() {
        sizeManager.SetNormalandNormal();
        brightAndMatManager.SetWoodandWood();
        cdManager.SetNormalWeight();
    }

    public void SetHeavyWeight() {
        sizeManager.SetSmallandSmall();
        brightAndMatManager.SetMetalandMetal();
        cdManager.SetHeavyWeight();
    }
}
