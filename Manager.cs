using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Source and reference for the code and most of the help is from Gamesplusjames 
//https://www.youtube.com/playlist?list=PLLPYMaP0tgFKZj5VG82316B63eet0Pvsv

public class Manager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public Beat theBS;

    public static Manager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 150;
    public int scorePerPerfectNote = 200;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;

    public Text scoreText;
    public Text multiText;
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.Starttime = true;

                theMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierThreshold.Length)
        {

            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMiss()
    {
        Debug.Log("Miss");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
