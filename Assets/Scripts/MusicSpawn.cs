using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicSpawn
{
    public int beat;
    public int spawnPoint;
    public GameObject spawnObject;

    public MusicSpawn() {
        beat = 0;
        spawnPoint = 0;
        spawnObject = null;
    }
}
