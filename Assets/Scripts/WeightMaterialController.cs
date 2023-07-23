using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMaterialController : MonoBehaviour
{
    [SerializeField] Renderer smallL;
    [SerializeField] Renderer bigL;

    [SerializeField] Renderer smallR;
    [SerializeField] Renderer BigR;


    public void SetMaterial(Material left, Material right) {
        smallL.material = left;
        bigL.material = left;

        smallR.material = right;
        BigR.material = right;
    }

    public void SetMaterial(Material leftS, Material leftB, Material rightS, Material rightB) {
        smallL.material = leftS;
        bigL.material = leftB;

        smallR.material = rightS;
        BigR.material = rightB;
    }
}
