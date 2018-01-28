using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMovement : MonoBehaviour {
    public Rigidbody2D rb;
    private Vector2 StartPosition;
	// Use this for initialization
	void Awake () {
        // rb.velocity = new Vector2(0, 2);
        StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0, 1);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = StartPosition;
        }
    }
}
