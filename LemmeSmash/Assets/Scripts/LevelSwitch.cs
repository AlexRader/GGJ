using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    private AudioClip myClip;
    private AudioSource myAudio;
    private float songLength;
    private int levelIndex;
    // Use this for initialization
    void Start ()
    {
		myAudio = GetComponent<AudioSource>();
        myClip = myAudio.clip;
        songLength = myClip.length;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update ()
    {
        songLength -= Time.deltaTime;
        if (songLength <= 0)
        {
            LevelChange();
        }
	}

    void LevelChange()
    {
        SceneManager.LoadScene(levelIndex + 1, LoadSceneMode.Single);
    }
}
