using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    [SerializeField] float small = 0.5f;
    [SerializeField] float medium = 1f;
    [SerializeField] float big = 1.5f;

    [SerializeField] Vector3 smallPositionR;
    [SerializeField] Vector3 mediumPositionR;
    [SerializeField] Vector3 bigPositionR;

    [SerializeField] Vector3 smallPositionL;
    [SerializeField] Vector3 mediumPositionL;
    [SerializeField] Vector3 bigPositionL;


    [SerializeField] GameObject rightHandle;
    [SerializeField] GameObject leftHandle;

    private Vector3 smallVec;
    private Vector3 mediumVec;
    private Vector3 bigVec;

    private void Start() {
        smallVec = new Vector3(small, small, small);
        mediumVec = new Vector3(medium, medium, medium);
        bigVec = new Vector3(big, big, big);
    }

    public void ResetHandle() {
        SetPosAndScale(mediumPositionR, mediumPositionL, mediumVec, mediumVec);
    }

    public void SetSmallandBig() {
        SetPosAndScale(smallPositionL, bigPositionR, smallVec, bigVec);
    }

    public void SetMediumandBig() {
        SetPosAndScale(mediumPositionL, bigPositionR, mediumVec, bigVec);
    }

    public void SetMediumandSmall() {
        SetPosAndScale(mediumPositionL, smallPositionR, mediumVec, smallVec);
    }

    public void SetBigandSmall() {
        SetPosAndScale(bigPositionL, smallPositionR, bigVec, smallVec);
    }

    public void SetBigandMedium() {
        SetPosAndScale(bigPositionL, mediumPositionR, bigVec, mediumVec);
    }

    public void SetSmallandMedium() {
        SetPosAndScale(smallPositionL, mediumPositionR, smallVec, mediumVec);
    }

    private void SetPosAndScale(Vector3 posL, Vector3 posR, Vector3 scaleL, Vector3 scaleR) {
        rightHandle.transform.position = posR;
        rightHandle.transform.localScale = scaleR;

        leftHandle.transform.position = posL;
        leftHandle.transform.localScale = scaleL;
    }
}
