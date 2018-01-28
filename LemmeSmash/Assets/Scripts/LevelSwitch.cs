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
    const float waitTime = 5.0f;
    private bool AudioPaused = false;
    // Use this for initialization
    void Start ()
    {
		myAudio = GetComponent<AudioSource>();
        songLength = myAudio.clip.length;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        started = false;
        myAudio.Pause();

        StartCoroutine(levelStart());
    }

    // Update is called once per frame
    void Update ()
    {
        if (started)
        {
            songLength -= Time.deltaTime;
        
            if (songLength <= 0)
            {
                LevelChange();
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

    void LevelChange()
    {
        SceneManager.LoadScene(levelIndex + 1, LoadSceneMode.Single);
    }
}
