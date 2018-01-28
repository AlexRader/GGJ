using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public AudioSource myAudio;
    private float songLength;
    private int levelIndex;
    public bool started;
    const float waitTime = 2.0f;
    private bool AudioPaused = false;
    public AudioSource Becky;
    public AudioClip Bad;
    public AudioClip Good;
    public GameObject goodVideo;

    public GameObject badVideo;

    public bool happened = false;
    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        songLength = myAudio.clip.length;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        started = false;
        myAudio.Pause();

        StartCoroutine(levelStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            songLength -= Time.deltaTime;

            if (songLength <= 0 && !happened)
            {
                happened = true;
                if (Score.score > 50)
                {
                    Becky.clip = Good;
                    Becky.Play();
                    Instantiate(goodVideo, Vector3.zero, Quaternion.identity);
                }

                else
                {
                    Becky.clip = Bad;
                    Becky.Play();
                    Instantiate(badVideo, Vector3.zero, Quaternion.identity);
                }
                StartCoroutine(LevelChange());

            }
        }
    }
    

    private IEnumerator levelStart()
    {
        yield return new WaitForSeconds(waitTime);
        myAudio.Play();
        CheckStart();
    }

    void CheckStart()
    {
        if (myAudio.isPlaying)
            started = true;
    }

    IEnumerator LevelChange()
    {
        yield return new WaitForSeconds(waitTime);
        if (Score.score > 50)
        {
            SceneManager.LoadScene(levelIndex + 1, LoadSceneMode.Single);
        }
        else
            SceneManager.LoadScene("EndFull", LoadSceneMode.Single);
    }
}

