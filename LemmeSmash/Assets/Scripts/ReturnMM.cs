using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMM : MonoBehaviour {

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         StartCoroutine(levelStart());
    }

    private IEnumerator levelStart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);

    }
}
