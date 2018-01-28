using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour {
    private Rigidbody2D rb;
    public KeyCode myKey;
    private const int buffer = 11;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(3,0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > buffer)
        {
            Destroy(gameObject);
            ModifyScore(-1);
        }
	}

    void ModifyScore(float ScoreChange)
    {
        Score.score += ScoreChange;
    }
}
