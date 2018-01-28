using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeat : MonoBehaviour {
    public Animator anim;
    public Image heart;

    public Sprite b_heart;
    public Sprite p_heart;
    public Sprite o_heart;
    public Sprite r_heart;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Score.score < 25)
        {
            anim.SetBool("break", true);
            anim.SetBool("fail", false);
            heart.sprite = b_heart;
        }

        if(25<Score.score && Score.score <50 )
        {
            anim.SetBool("break", false);
            anim.SetBool("pass", false);
            anim.SetBool("fail", true);
            heart.sprite = p_heart;

        }

        if (50 < Score.score && Score.score < 75)
        {
            anim.SetBool("best", false);
            anim.SetBool("pass", true);
            anim.SetBool("fail", false);
            heart.sprite = o_heart;
        }

        if (75 < Score.score && Score.score < 100)
        {
            
            anim.SetBool("pass", false);
            anim.SetBool("best", true);
            heart.sprite = r_heart;
        }



    }
}
