using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissedNotes : MonoBehaviour {

    [SerializeField]
    public static float notesMissed;

    
	// Use this for initialization
	void Start () {
        notesMissed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        notesMissed += 1;
        //missed note effect plays
    }
}
