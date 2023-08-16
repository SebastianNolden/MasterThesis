using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCreator : MonoBehaviour
{
    [SerializeField] GameObject track;
    [SerializeField] Song song;
    [SerializeField] GameObject[] gameobjects;

    [ContextMenu("CreateSongtrackFromObjectTrack")]
    public void CreateTrackIntoSong() {
        // Track creation into array
        List<MusicSpawn> track_array = new List<MusicSpawn>();

        foreach (Transform child in track.transform) {
            MusicSpawn musicSpawn = new();

            // set Beat
            musicSpawn.beat = (int) Mathf.Abs(child.position.x);
            // set Spawnpoint
            musicSpawn.spawnPoint = GetSpawnPoint(child.position);
            // set Spawnobject
            musicSpawn.spawnObject = GetGameobjectByString(child.name);

            track_array.Add(musicSpawn);
        }

        // add Array to Song
        song.musicSpawn = track_array;

        Debug.Log("Track was generated in " + song.name);
    }

    private int GetSpawnPoint(Vector3 position) {
        int point;
        int xValue = (int) Mathf.Abs(position.z);
        int yValue = (int) position.y;

        switch((xValue, yValue)) {
            case (0,0):
                point = 0;
                break;
            case (0, 1):
                point = 3;
                break;
            case (0, 2):
                point = 6;
                break;
            case (1, 0):
                point = 1;
                break;
            case (1, 1):
                point = 4;
                break;
            case (1, 2):
                point = 7;
                break;
            case (2, 0):
                point = 2;
                break;
            case (2, 1):
                point = 5;
                break;
            case (2, 2):
                point = 8;
                break;
            default:
                point = 0;
                break;
        }

        return point;
    }
    
    private GameObject GetGameobjectByString(string name) {
        int i_name = int.Parse(name.Substring(0,1));
        return gameobjects[i_name];
    }
}
