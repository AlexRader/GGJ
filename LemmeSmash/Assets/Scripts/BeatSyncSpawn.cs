using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSyncSpawn : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject[] startLane;

    public float bpm;
    private float lastPlayed, DT, timer;

    private int randomInt;

    private AudioSource myAudio;

    // Use this for initialization
    void Start ()
    {
        lastPlayed = 0;
        DT = 0;
        timer = 0;
        randomInt = 0;
        myAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update ()
    {
        DT = myAudio.time - lastPlayed;
        timer += DT;

        if (timer >= (60 / bpm))
            SpawnSystem();

        lastPlayed = myAudio.time;
	}

    void SpawnSystem()
    {
        randomInt = Random.Range(0, notes.Length);
        Instantiate(notes[randomInt], startLane[randomInt].transform.position, startLane[randomInt].transform.rotation);
        timer -= 60f / bpm;
    }
}
