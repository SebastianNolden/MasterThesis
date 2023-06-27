using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioClip audioClip;  // The audio clip to be looped
    public float fadeInDuration = 1.5f;  // Duration of the fade-in effect in seconds
    public float fadeOutDuration = 1.5f;  // Duration of the fade-out effect in seconds
    public float audioSourceMaxVolume = 1f;

    private AudioSource audioSource;
    private bool isFadingIn;
    private float currentFadeTime;
    private float remainingTime;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = false;  // Disable initial looping to handle it manually

        currentFadeTime = 0f;
        remainingTime = audioSource.clip.length;
    }

    private void Update() {
        AudioLoop();
    }

    private void AudioLoop() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
            isFadingIn = true;
        }

        Fading();

        remainingTime = audioSource.clip.length - audioSource.time;
    }

    private void Fading() {
        if (isFadingIn) {
            FadeIn();
        } else if (TimeForFadeOut()) {
            FadeOut();
        }
    }

    private bool TimeForFadeOut() {
        return remainingTime <= fadeOutDuration;
    }

    private void FadeIn() {
        currentFadeTime += Time.deltaTime;
        float volume = currentFadeTime / audioSourceMaxVolume;
        audioSource.volume = volume;

        if (currentFadeTime >= fadeInDuration) {
            isFadingIn = false;
            audioSource.volume = audioSourceMaxVolume;
            currentFadeTime = 0f;
        }
    }

    private void FadeOut() {
        currentFadeTime += Time.deltaTime;
        float volume = remainingTime / fadeOutDuration;
        audioSource.volume = volume;

        if (currentFadeTime >= fadeOutDuration) {
            audioSource.volume = 0f;
            audioSource.Stop();
        }
    }

}
