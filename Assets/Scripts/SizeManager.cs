using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    [SerializeField] GameObject dumbbellNormalL;
    [SerializeField] GameObject dumbbellHalfL;
    [SerializeField] GameObject dumbbellOneandhalfL;

    [SerializeField] GameObject dumbbellNormalR;
    [SerializeField] GameObject dumbbellHalfR;
    [SerializeField] GameObject dumbbellOneandhalfR;

    [ContextMenu("ResetHandle")]
    public void ResetHandle() {
        SetObjectActive(dumbbellNormalL, dumbbellNormalR);
    }

    [ContextMenu("SetSmallandBig")]
    public void SetSmallandBig() {
        SetObjectActive(dumbbellHalfL, dumbbellOneandhalfR);
    }

    [ContextMenu("SetMediumandBig")]
    public void SetMediumandBig() {
        SetObjectActive(dumbbellNormalL, dumbbellOneandhalfR);
    }

    [ContextMenu("SetMediumandSmall")]
    public void SetMediumandSmall() {
        SetObjectActive(dumbbellNormalL, dumbbellHalfR);
    }

    [ContextMenu("SetBigandSmall")]
    public void SetBigandSmall() {
        SetObjectActive(dumbbellOneandhalfL, dumbbellHalfR);
    }

    [ContextMenu("SetBigandMedium")]
    public void SetBigandMedium() {
        SetObjectActive(dumbbellOneandhalfL, dumbbellNormalR);
    }

    [ContextMenu("SetSmallandMedium")]
    public void SetSmallandMedium() {
        SetObjectActive(dumbbellHalfL, dumbbellNormalR);
    }

    public void SetNormalandNormal() {
        SetObjectActive(dumbbellNormalL, dumbbellNormalR);
    }

    public void SetSmallandSmall() {
        SetObjectActive(dumbbellHalfL, dumbbellHalfR);
    }

    public void SetBigandBig() {
        SetObjectActive(dumbbellOneandhalfL, dumbbellOneandhalfL);
    }

    private void DeactivateAll() {
        dumbbellHalfL.SetActive(false);
        dumbbellNormalL.SetActive(false);
        dumbbellOneandhalfL.SetActive(false);

        dumbbellHalfR.SetActive(false);
        dumbbellNormalR.SetActive(false);
        dumbbellOneandhalfR.SetActive(false);
    }

    private void SetObjectActive(GameObject left, GameObject right) {
        DeactivateAll();
        left.SetActive(true);
        right.SetActive(true);
    }
}
