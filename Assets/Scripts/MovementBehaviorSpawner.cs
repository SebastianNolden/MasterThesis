using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviorSpawner : MonoBehaviour
{
    [SerializeField] float timeToPlaySongInSeconds = 10f;
    [SerializeField] int secondsForEndFaiding = 5;
    [SerializeField] float faidingValue = 1f;
    [Range(0, 1)]
    [SerializeField] float audioVolume = 1f;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Song song;
    [SerializeField] GameObject parentForSpawnedObjects;
    [SerializeField] StudyController studyController;

    float secPerBeat = 0f;
    float songPosition = 0f;
    float songPositionInBeats = 0f;
    float dspSongTime = 0f;
    int positionInArray = 0;
    bool spawning = false;

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) {
            UpdateSongPosition();
            if (spawning) SpawnGameobjects();
        } 

        if (songPosition >= timeToPlaySongInSeconds && audioSource.isPlaying) {
            audioSource.volume -= faidingValue * Time.deltaTime;
            spawning = false;
        }

        if (songPosition >= (timeToPlaySongInSeconds + secondsForEndFaiding) && audioSource.isPlaying) {
            EndSong();
        }
    }

    private void EndSong() {
        audioSource.Stop();
        studyController.SongEnded();
    }

    public void StartSong() {
        // Calculate the number of seconds in each beat
        secPerBeat = 60f / song.songBpm;

        // Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        // Start the music
        audioSource.clip = song.song;
        audioSource.volume = audioVolume;
        audioSource.Play();
        spawning = true;

        // reset spawncounter
        positionInArray = 0;
    }

    private void SpawnGameobjects() {
        // convert from float to int
        int songPositionInBeatsConverted = (int)songPositionInBeats;

        // Nothing to spawn anymore, stop function here
        if (positionInArray >= song.musicSpawn.Count) return;

        while(song.musicSpawn[positionInArray].beat == songPositionInBeatsConverted) {
            
            GameObject spawnObject = song.musicSpawn[positionInArray].spawnObject;
            GameObject spawn = GetSpawnPointByNumber(song.musicSpawn[positionInArray].spawnPoint);
            Instantiate(spawnObject, spawn.transform.position, Quaternion.identity, parentForSpawnedObjects.transform);

            if (++positionInArray >= song.musicSpawn.Count) break;
        }
    }

    private void UpdateSongPosition() {
        // determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - song.firstBeatOffset);

        // determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }

    /***
     * 0 - 1 - 2 - 3 | 4 - 5 - - 7 | 8 - 9 - 10 - 11
     */
    private GameObject GetSpawnPointByNumber(int number) {
        return spawnPoints[number];
    }
}
