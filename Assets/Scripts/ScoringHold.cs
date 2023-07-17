using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringHold : MonoBehaviour
{
    public int scoreMultiplier = 10;

    bool isColliding = false;
    float scoringTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isColliding) {
            scoringTime += Time.deltaTime;
        } 
    }

    private void Reset() {
        Score.Instance.AddScore((int) (scoringTime * scoreMultiplier));
        scoringTime = 0f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Hand") {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Hand") {
            Reset();
            isColliding = false;
        }
    }
}
