using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song", menuName = "ScriptableObjects/Songs", order = 1)]
public class Song : ScriptableObject
{
    public AudioClip song;
    public float songBpm = 0f;
    public float firstBeatOffset = 0f;
    public List<MusicSpawn> musicSpawn;
}
