using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] InteractableHands rightHands;
    [SerializeField] InteractableHands leftHands;

    [SerializeField] GameObject startStudyButton;
    [SerializeField] GameObject nextConditionButton;
    [SerializeField] GameObject selectStudy;

    [SerializeField] GameObject studyCodeUI;
 
    private void Start() {
        SetHandsInteractable(true);
    }

    public void SetHandsInteractable(bool active) {
        rightHands.ActivateInteractableHands(active);
        leftHands.ActivateInteractableHands(active);
    }

    public void SetNextConditionButton() {
        SetHandsInteractable(true);
        nextConditionButton.SetActive(true);
    }

    public void StudyEnded() {
        SetHandsInteractable(true);
        SetStartStudyButton(true);
        selectStudy.SetActive(true);
        SetStudyCodeUI(false);
    }

    private void SetStartStudyButton(bool active) {
        startStudyButton.SetActive(active);
    }

    private void SetStudyCodeUI(bool active) {
        studyCodeUI.SetActive(active);
    }
}
