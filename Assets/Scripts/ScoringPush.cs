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
    [SerializeField] float destroyTimeInSeconds = 0.5f;

    AudioSource audioSource;
    bool gotHit = false;
    MeshRenderer meshRenderer;

    private void Start() {
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.clip = clip;

        meshRenderer = transform.GetComponent<MeshRenderer>();

        gotHit = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Hand") {
            // check for velocity of Hand
            if (other.gameObject.GetComponent<HandVelocity>().GetHandVelocity() < velocityMinimum) return;

            if (!gotHit) {
                gotHit = true;
                
                //AudioSource.PlayClipAtPoint(clip, transform.position, clipVolume);
                audioSource.Play();

                // Send haptic feedback
                other.gameObject.GetComponentInParent<VRController>().SendHapticImpulse(intensity, duration);

                // disable the Mesh of the Ball
                meshRenderer.enabled = false;

                Score.Instance.AddScore(score);

                // Destroy Ball
                Destroy(this.gameObject, destroyTimeInSeconds);
                // Destroy(this.gameObject);
            }
        }
    }
}
