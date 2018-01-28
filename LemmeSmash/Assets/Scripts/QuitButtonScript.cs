using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour {

	public GameObject manager;
	SpriteRenderer sr;
	public Sprite closed;
	public Sprite open;
	MenuManagerScript mms;
	AudioSource blip;

	void Start(){
		sr = gameObject.GetComponent<SpriteRenderer> ();
		manager = GameObject.Find ("Menu_Manager");
		mms = manager.GetComponent<MenuManagerScript> ();
		blip = gameObject.GetComponent<AudioSource> ();
	}

	void OnMouseEnter(){
		blip.Play();
		sr.sprite = open;
	}

	void OnMouseExit(){
		blip.Play ();
		sr.sprite = closed;
	}

	void OnMouseDown(){
		Application.Quit ();
	}
}
