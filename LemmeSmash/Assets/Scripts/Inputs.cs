using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Vector4 activeKeys;
    public Vector4 collisionKeys;
    int setNumb = 1;
    public GameObject beatCheck;
    public Animator anim;

    private bool canDestroy;
    private bool canDestroy2;
    private bool canDestroy3;
    private bool canDestroy4;

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
        {
            activeKeys.x = setNumb;
            anim.SetBool("UpPressed", true);
        }
          
        if (Input.GetKeyDown(KeyCode.DownArrow))
            activeKeys.y = setNumb;
       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            activeKeys.z = setNumb;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            activeKeys.w = setNumb;
        if(Input.anyKeyDown)
            RunChecks();
    }

    void RunChecks()
    {
        if (activeKeys.x != 0)
        {
            //if the key was pressed right
            if (collisionKeys.x - activeKeys.x == 0)
            {
                ModifyScore(1);
                canDestroy = true;
                Debug.Log("boom");
            }
            else if (collisionKeys.x - activeKeys.x < 0)//if the key was pressed wrong
            {
                //ModifyScore(-1);
                //Debug.Log("boom");
            }

           
        }   //ModScorehere}
        if (activeKeys.y != 0)
        {
            //if the key was pressed right
            if (collisionKeys.y - activeKeys.y == 0)
            {
                canDestroy2 = true;
                ModifyScore(1);
            }
            else if (collisionKeys.y - activeKeys.y < 0)//if the key was pressed wrong
            {
                //ModifyScore(-0.25f);
            }
        }   //ModScorehere}
        if (activeKeys.z != 0)
        {
            //if the key was pressed right
            if (collisionKeys.z - activeKeys.z == 0)
            {
                canDestroy3 = true;
                ModifyScore(1);
            }
            else if (collisionKeys.z - activeKeys.z < 0)//if the key was pressed wrong
            {
                //ModifyScore(-0.25f);
            }
        }   //ModScorehere}
        if (activeKeys.w != 0)
        {
            //if the key was pressed right
            if (collisionKeys.w - activeKeys.w == 0)
            {
                canDestroy4 = true;
                ModifyScore(1);
            }
            else if (collisionKeys.w - activeKeys.w < 0)//if the key was pressed wrong
            {
               // ModifyScore(-0.25f);
            }
        }   //ModScorehere}
        activeKeys = Vector4.zero;
    }

    void ModifyScore(float ScoreChange)
    {
        Score.score += ScoreChange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("hit");
        if (collision.gameObject.tag.Equals("Up"))
            collisionKeys.x += setNumb;
        //collisionKeys.x = setNumb;
        if (collision.gameObject.tag.Equals("Down"))
            collisionKeys.y += setNumb;
        if (collision.gameObject.tag.Equals("Left"))
            collisionKeys.z += setNumb;
        if (collision.gameObject.tag.Equals("Right"))
            collisionKeys.w += setNumb;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Up"))
        {
            //collisionKeys.x = 0;
            collisionKeys.x -= setNumb;
            if (canDestroy)
            {
                Destroy(collision.gameObject);
                canDestroy = false;
            }

            else
            {
                ModifyScore(-1);
            }
        }

        if (collision.gameObject.tag.Equals("Down"))
        {
            collisionKeys.y -= setNumb;
            if (canDestroy2)
            {
                Destroy(collision.gameObject);
                canDestroy2 = false;
                Debug.Log("killed");
            }

            else
            {
                ModifyScore(-1);
            }
        }
        if (collision.gameObject.tag.Equals("Left"))
        {
            collisionKeys.z -= setNumb;

            if (canDestroy3)
            {
                Destroy(collision.gameObject);
                canDestroy3 = false;
            }
            else
            {
                ModifyScore(-1);
            }
        }
        if (collision.gameObject.tag.Equals("Right"))
        {
            collisionKeys.w -= setNumb;
            if (canDestroy4)
            {
                Destroy(collision.gameObject);
                canDestroy4 = false;
            }

            else
            {
                ModifyScore(-1);
            }
        }
       
    }

}
