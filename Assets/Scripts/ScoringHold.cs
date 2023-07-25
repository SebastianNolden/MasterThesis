using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringHold : MonoBehaviour
{
    [SerializeField] int scoreMultiplier = 10;
    [Range(0, 1)]
    [SerializeField] float intensity;
    [SerializeField] float duration;

    bool isColliding = false;
    float scoringTime = 0f;
    Collider col;

    // Update is called once per frame
    void Update()
    {
        if (isColliding) {
            scoringTime += Time.deltaTime;

            if (col != null) col.gameObject.GetComponentInParent<VRController>().SendHapticImpulse(intensity, duration);
        } 
    }

    private void Reset() {
        Score.Instance.AddScore((int) (scoringTime * scoreMultiplier));
        scoringTime = 0f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Hand") {
            isColliding = true;
            col = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Hand") {
            Reset();
            isColliding = false;
            col = null;
        }
    }
}
