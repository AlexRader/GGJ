using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

   private bool counting = true;

    private float counter;
    public float spawnInterval;

    public GameObject Note;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        spawnInterval = Random.Range(1, 6); //creates random number for distance between notes

		if(counting)
        {
            counter += Time.deltaTime;
        }

        if(counter > spawnInterval) //time check between instantiation
        {
            Instantiate(Note, transform.position, Quaternion.identity);
            counter = 0;
        }
	}
}
