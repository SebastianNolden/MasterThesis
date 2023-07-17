using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPush : MonoBehaviour
{
    public int score = 1;
    public float velocityMinimum = 2f;
    [Range(0,1)]
    public float clipVolume = 1f;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Hand") {
            // check for velocity of Hand
            if (other.gameObject.GetComponent<HandVelocity>().GetHandVelocity() < velocityMinimum) return;

            AudioSource.PlayClipAtPoint(clip, transform.position, clipVolume);

            Score.Instance.AddScore(score);

            // Destroy Ball
            Destroy(this.gameObject);
        }
    }
}
