using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPush : MonoBehaviour
{
    [SerializeField] int score = 1;
    [SerializeField] float velocityMinimum = 2f;
    [Range(0,1)]
    [SerializeField] float clipVolume = 1f;
    [SerializeField] AudioClip clip;
    [Range(0, 1)]
    [SerializeField] float intensity;
    [SerializeField] float duration;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Hand") {
            // check for velocity of Hand
            if (other.gameObject.GetComponent<HandVelocity>().GetHandVelocity() < velocityMinimum) return;

            other.gameObject.GetComponentInParent<VRController>().SendHapticImpulse(intensity, duration);

            AudioSource.PlayClipAtPoint(clip, transform.position, clipVolume);

            Score.Instance.AddScore(score);

            // Destroy Ball
            Destroy(this.gameObject);
        }
    }
}
