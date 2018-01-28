using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public KeyCode theKey;
    private GameObject collidedObject;
    private bool hit = false;
    private bool hasCollided = false;
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;


    private void Awake()
    {
        Event e = Event.current;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("upPressed", true);

            anim.SetBool("leftPressed", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("downPressed", false);

            anim2.SetBool("Pressed", true);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("downPressed", true);

            anim.SetBool("leftPressed", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("upPressed", false);

            anim3.SetBool("Pressed", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("leftPressed", true);

            anim.SetBool("upPressed", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("downPressed", false);

            anim4.SetBool("Pressed", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("rightPressed", true);

            anim.SetBool("leftPressed", false);
            anim.SetBool("upPressed", false);
            anim.SetBool("downPressed", false);

            anim5.SetBool("Pressed", true);

        }


    }

    void LateUpdate()
    {
        anim2.SetBool("Pressed", false);
        anim3.SetBool("Pressed", false);
        anim4.SetBool("Pressed", false);
        anim5.SetBool("Pressed", false);
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey)
        {
            if (e.keyCode == theKey)
            {
                hit = true;
                RunChecks();
                e = null;
            }
        }

    }

    void InputCheck()
    {

        RunChecks();

        
    }

    void RunChecks()
    {
        if (collidedObject != null && hit)
        {
            if (Score.score < 101)
            {
                ModifyScore(0.35f);
            }
            Destroy(collidedObject);
            hit = false;
            collidedObject = null;
            hasCollided = false;
        }
    }

    void ModifyScore(float ScoreChange)
    {
        Score.score += ScoreChange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
        hasCollided = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
        collidedObject = null;
        hasCollided = false;
    }
}
