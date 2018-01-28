using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public KeyCode theKey;
    private GameObject collidedObject;
    private bool hit = false;
    private bool hasCollided = false;

    private void Awake()
    {
        Event e = Event.current;
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
