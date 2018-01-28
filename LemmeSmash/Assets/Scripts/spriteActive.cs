using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteActive : MonoBehaviour {

    SpriteRenderer spr;
	// Use this for initialization
	void Start ()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        spr.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void setActive()
    {

        spr.enabled = !spr.enabled;
    }
}
