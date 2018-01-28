using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSyncSpawn : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject[] startLane;

    private GameObject[] deleteNotes;

    public float bpm;
    private float lastPlayed, DT, timer;

    private int randomInt;

    private AudioSource myAudio;

    private bool frenzier = false;

    private float lastKey;

    private float superScoreModifier;

    private const float maxTime = 10.0f;
    private float frenzyTime;
    private bool wasActive;

    private float timeTillNextFrenzy = 0;

    // Use this for initialization
    void Start ()
    {
        lastPlayed = 0;
        DT = 0;
        timer = 0;
        randomInt = 0;
        myAudio = GetComponent<AudioSource>();
        lastKey = 0;
        superScoreModifier = 0;
        frenzyTime = maxTime;
        wasActive = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Score.score <= Score.frenzy && !frenzier && timeTillNextFrenzy <= 0)
            FrenzyChange();
        if (!frenzier)
        {
            DT = myAudio.time - lastPlayed;
            timer += DT;

            if (timer >= (60 / bpm))
                SpawnSystem();

            lastPlayed = myAudio.time;
            if (wasActive)
            {
                lastPlayed += 10;
                wasActive = false;
            }
            timeTillNextFrenzy -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                if (lastKey != 273)
                    superScoreModifier += .1f;
                lastKey = 273;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                if (lastKey != 274)
                    superScoreModifier += .1f;
                lastKey = 274;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) )
            {
                if (lastKey != 276)
                    superScoreModifier += .1f;
                lastKey = 276;

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (lastKey != 275)
                    superScoreModifier += .1f;
                lastKey = 275;
            }
            frenzyTime -= Time.deltaTime;
            if (frenzyTime <= 0)
            {
                FrenzyChange();
                if (Score.frenzy > superScoreModifier + Score.score)
                    superScoreModifier += (Score.frenzy - (superScoreModifier + Score.score));
                ModifyScore(superScoreModifier + 5);
                frenzyTime = maxTime;
                timeTillNextFrenzy = maxTime * 2;
            }
        }
	}

    void ModifyScore(float ScoreChange)
    {
        Score.score += ScoreChange;
        superScoreModifier = 0; 
    }

    void FrenzyChange()
    {
        frenzier = !frenzier;
        deleteNotes = GameObject.FindGameObjectsWithTag("Up");
        for (int i = 0; i < deleteNotes.Length; i++)
        {
            Destroy(deleteNotes[i].gameObject);
        }
        deleteNotes = GameObject.FindGameObjectsWithTag("Down");
        for (int i = 0; i < deleteNotes.Length; i++)
        {
            Destroy(deleteNotes[i].gameObject);
        }
        deleteNotes = GameObject.FindGameObjectsWithTag("Left");
        for (int i = 0; i < deleteNotes.Length; i++)
        {
            Destroy(deleteNotes[i].gameObject);
        }
        deleteNotes = GameObject.FindGameObjectsWithTag("Right");
        for (int i = 0; i < deleteNotes.Length; i++)
        {
            Destroy(deleteNotes[i].gameObject);
        }
        wasActive = true;
    }

    void SpawnSystem()
    {
        randomInt = Random.Range(0, notes.Length);
        Instantiate(notes[randomInt], startLane[randomInt].transform.position, startLane[randomInt].transform.rotation);
        timer -= 60f / bpm;
    }
}
