using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Vector4 activeKeys;
    public Vector4 collisionKeys;
    int setNumb = 1;
    public GameObject beatCheck;

    // Use this for initialization
    void Start()
    {
        activeKeys = Vector4.zero;
        collisionKeys = Vector4.zero;
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            activeKeys.x = setNumb;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            activeKeys.y = setNumb;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            activeKeys.z = setNumb;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            activeKeys.w = setNumb;

        RunChecks();
    }

    void RunChecks()
    {
        if (activeKeys.x != 0)
        {
            //if the key was pressed right
            if (collisionKeys.x - activeKeys.x == 0)
            { }
            else if (collisionKeys.x - activeKeys.x < 0)//if the key was pressed wrong
            { }
        }   //ModScorehere}
        if (activeKeys.y != 0)
        {
            //if the key was pressed right
            if (collisionKeys.y - activeKeys.y == 0)
            { }
            else if (collisionKeys.y - activeKeys.y < 0)//if the key was pressed wrong
            { }
        }   //ModScorehere}
        if (activeKeys.z != 0)
        {
            //if the key was pressed right
            if (collisionKeys.z - activeKeys.z == 0)
            { }
            else if (collisionKeys.z - activeKeys.z < 0)//if the key was pressed wrong
            { }
        }   //ModScorehere}
        if (activeKeys.w != 0)
        {
            //if the key was pressed right
            if (collisionKeys.w - activeKeys.w == 0)
            { }
            else if (collisionKeys.w - activeKeys.w < 0)//if the key was pressed wrong
            { }
        }   //ModScorehere}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("up"))
            collisionKeys.x += setNumb;
        if (collision.gameObject.tag.Equals("down"))
            collisionKeys.y += setNumb;
        if (collision.gameObject.tag.Equals("left"))
            collisionKeys.z += setNumb;
        if (collision.gameObject.tag.Equals("right"))
            collisionKeys.w += setNumb;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("up"))
            collisionKeys.x -= setNumb;
        if (collision.gameObject.tag.Equals("down"))
            collisionKeys.y -= setNumb;
        if (collision.gameObject.tag.Equals("left"))
            collisionKeys.z -= setNumb;
        if (collision.gameObject.tag.Equals("right"))
            collisionKeys.w -= setNumb;
    }

}
