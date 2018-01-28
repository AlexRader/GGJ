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

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("downPressed", true);

            anim.SetBool("leftPressed", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("upPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("leftPressed", true);

            anim.SetBool("upPressed", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("downPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("rightPressed", true);

            anim.SetBool("leftPressed", false);
            anim.SetBool("upPressed", false);
            anim.SetBool("downPressed", false);

        }

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
            ModifyScore(1);
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
