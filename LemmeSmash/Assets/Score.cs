using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    public static float score;

    public Slider SmashoMeter;

    public GameObject frenzyChanger;

    [SerializeField]
    public static float frenzy = 20;

    // Use this for initialization
    void Start()
    {
        score = 35;
    }

    // Update is called once per frame
    void Update()
    {
        
        SmashoMeter.value = score;
        score -= MissedNotes.notesMissed;
        

        //Frenzy();
        Victory();
        //Test();
    }
    /*
    void Frenzy()
    {
        if(score <= 20)
        {
            frenzyChanger.GetComponent<BeatSyncSpawn>().SendMessage("FrenzyChange");
            //altered color scheme + animation set
            //frenzy mode
        }
    }*/

    void Victory()
    {
        if (score >= 50)
        {
            //victory effect
            //transition to next level
        }
    }

    /* void Test()
     {
         if(Input.GetKeyDown(KeyCode.A))
         {
             score -= 1;
         }

         if (Input.GetKeyDown(KeyCode.D))
         {
             score += 1;
         }
     }*/
}
