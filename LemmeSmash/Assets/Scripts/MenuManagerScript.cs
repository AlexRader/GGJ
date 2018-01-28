using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

	public GameObject faderFab;
	public GameObject mainMenu;
	public GameObject creditScreen;
	public GameObject controlPage;

	float delayTransition = 0.7f;
	float delayConstant = 0.7f;
	bool countdown = false;
	bool goToMain = false;
	bool goToCredits = false;
	bool goToControls = false;
	bool startGame = false;

    private int levelIndex;

    public void Transition(){
		Instantiate (faderFab);
	}

    void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update(){
		if (countdown) {
			delayTransition -= Time.deltaTime;
			if (delayTransition <= 0) {
				if (goToMain) {
					MenuOn ();
				} else if (goToCredits) {
					CreditsOn ();
				} else if (goToControls) {
					ControlsOn ();
				} else if (startGame) {
					Debug.Log ("game time binches");
                    SceneManager.LoadScene(levelIndex + 1, LoadSceneMode.Single);
                }
				countdown = false;
				delayTransition = delayConstant;
			}
		}
	}

	public void PlayGame(){
		Transition ();
		countdown = true;
		startGame = true;
	}

	public void GoToControls(){
		Transition ();
		countdown = true;
		goToControls = true;
	}

	public void GoTOCredits(){
		Transition ();
		countdown = true;
		goToCredits = true;
	}

	public void GoToMenu(){
		Transition ();
		countdown = true;
		goToMain = true;
	}

	void MenuOn(){
		goToMain = false;
		mainMenu.SetActive (true);
		creditScreen.SetActive (false);
		controlPage.SetActive (false);
	}

	void CreditsOn (){
		goToCredits = false;
		mainMenu.SetActive (false);
		creditScreen.SetActive (true);
		controlPage.SetActive (false);
	}

	void ControlsOn(){
		goToControls = false;
		mainMenu.SetActive (false);
		creditScreen.SetActive (false);
		controlPage.SetActive (true);
	}

}