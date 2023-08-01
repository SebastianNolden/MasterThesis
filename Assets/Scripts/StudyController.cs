using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Size = 0, Material = 1, Brightness = 2, CDRatio = 3;
public enum StudyOption {
    Size,
    Material,
    Brightness,
    CDRatio,
    AllTogether
}

public class StudyController : MonoBehaviour
{
    [SerializeField] TextMeshPro studyTextUI;
    [SerializeField] MenuController menuController;
    [SerializeField] SizeManager sizeManager;
    [SerializeField] BrightnessAndMaterialManager brightAndMatManager;
    [SerializeField] CDRatioManager cdManager;
    [SerializeField] AllTogetherStudy allTogether;

    private StudyOption currentStudyOption;
    private StudyOption[] studyCode;
    private char studyVersion;
    private int subStudyCounter = 0;
    private int studyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        studyCode = new StudyOption[5];
        currentStudyOption = StudyOption.Size;
        subStudyCounter = 0;
        studyCounter = 0;
    }

    public void SongEnded() {
        // either set next Song Button or start Study Button
        // set studyCode deactive here if start Study Button is called!
        if (currentStudyOption == StudyOption.AllTogether && subStudyCounter == 2) {
            menuController.StudyEnded();
        } else {
            menuController.SetNextSongButton();
        }

        if (subStudyCounter == 2) {
            NextStudy();
            subStudyCounter = 0;
        } else {
            subStudyCounter++;
        }

        // Reset all features!
        ResetAllFeatures();
    }

    private void NextStudy() {
        currentStudyOption = studyCode[++studyCounter];

        // studie ended
        if (currentStudyOption == StudyOption.AllTogether && subStudyCounter == 2) studyCounter = 0;
    }

    private void ResetAllFeatures() {
        sizeManager.ResetHandle();
        brightAndMatManager.ResetHandle();
        cdManager.ResetHandle();
    }

    public void SetNextSongProperties() {
        switch (currentStudyOption) {
            case StudyOption.Size:
                SizeFeature();
                break;
            case StudyOption.Material:
                MaterialFeature();
                break;
            case StudyOption.Brightness:
                BrightnessFeature();
                break;
            case StudyOption.CDRatio:
                CDRatioFeature();
                break;
            case StudyOption.AllTogether:
                AllTogetherFeature();
                break;
            default:
                // something broke!
                break;
        }
    }

    private void AllTogetherFeature() {
        if (subStudyCounter == 0) allTogether.SetLightWeight();
        if (subStudyCounter == 1) allTogether.SetNormalWeight();
        if (subStudyCounter == 2) allTogether.SetHeavyWeight();
    }

    private void CDRatioFeature() {
        if (subStudyCounter == 0) cdManager.SetLightWeight();
        if (subStudyCounter == 1) cdManager.SetNormalWeight();
        if (subStudyCounter == 2) cdManager.SetHeavyWeight();
    }

    private void BrightnessFeature() {
        if (studyVersion == 'A') {
            if (subStudyCounter == 0) brightAndMatManager.SetNormalandDarker();
            if (subStudyCounter == 1) brightAndMatManager.SetNormalandDarkest();
            if (subStudyCounter == 2) brightAndMatManager.SetDarkestandDarker();
        } else {
            if (subStudyCounter == 0) brightAndMatManager.SetDarkerandNormal();
            if (subStudyCounter == 1) brightAndMatManager.SetDarkestandNormal();
            if (subStudyCounter == 2) brightAndMatManager.SetDarkerandDarkest();
        }
    }

    private void MaterialFeature() {
        if (studyVersion == 'A') {
            if (subStudyCounter == 0) brightAndMatManager.SetWoodandNormal();
            if (subStudyCounter == 1) brightAndMatManager.SetWoodandPoly();
            if (subStudyCounter == 2) brightAndMatManager.SetNormalandPoly();
        } else {
            if (subStudyCounter == 0) brightAndMatManager.SetNormalandWood();
            if (subStudyCounter == 1) brightAndMatManager.SetPolyandWood();
            if (subStudyCounter == 2) brightAndMatManager.SetPolyandNormal();
        }
    }

    private void SizeFeature() {
        if (studyVersion == 'A') {
            if (subStudyCounter == 0) sizeManager.SetSmallandMedium();
            if (subStudyCounter == 1) sizeManager.SetSmallandBig();
            if (subStudyCounter == 2) sizeManager.SetBigandMedium();
        } else {
            if (subStudyCounter == 0) sizeManager.SetMediumandSmall();
            if (subStudyCounter == 1) sizeManager.SetBigandSmall();
            if (subStudyCounter == 2) sizeManager.SetMediumandBig();
        }
    }

    public void CreateStudyCode() {
        int AorB = Random.Range(0, 2);
        studyVersion = (AorB == 0) ? 'A' : 'B';

        int studyOption = Random.Range(0, 3);
        switch(studyOption) {
            case 0:
                studyCode[0] = StudyOption.Size;
                studyCode[1] = StudyOption.Material;
                studyCode[2] = StudyOption.Brightness;
                break;
            case 1:
                studyCode[0] = StudyOption.Material;
                studyCode[1] = StudyOption.Brightness;
                studyCode[2] = StudyOption.Size;
                break;
            case 2:
                studyCode[0] = StudyOption.Brightness;
                studyCode[1] = StudyOption.Size;
                studyCode[2] = StudyOption.Material;
                break;
            default:
                // An error occured!
                break;
        }

        studyCode[3] = StudyOption.CDRatio;
        studyCode[4] = StudyOption.AllTogether;

        studyTextUI.text = StudyCodeToString();
        currentStudyOption = studyCode[0];
    }

    private string StudyCodeToString() {
        string study = "";

        // create code here
        study += studyVersion;
        foreach (var item in studyCode) {
            study += ("" + (int) item);
        }

        return study;
    }
}
