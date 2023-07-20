using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshPro value;
    
    private int score = 0;


    public static Score Instance { get; private set; }

    private void Awake() {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void AddScore(int addScore) {
        score += addScore;
        UpdateScore();
    }

    private void UpdateScore() {
        // Update visual Score in game here
        value.text = score + "";
    }
}
