using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour {

	public float timeLeft = 8f;

	void Update(){
		gameObject.transform.Translate (-1f, 0, 0, Space.Self);
		timeLeft -= Time.deltaTime;
	}

	void Start(){
		Destroy (gameObject, 8f);
	}
}
