using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blah : MonoBehaviour {

    public static int levelIndex = 0;
    // Use this for initialization
    void Start () {
        levelIndex += 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "VictoryScene")
        {
            StartCoroutine(levelStart());
        }
    }

    private IEnumerator levelStart()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);

    }


}
