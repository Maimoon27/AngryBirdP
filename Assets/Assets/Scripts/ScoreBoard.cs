using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Scoreboard {

    private static Scoreboard instance; //we make this static because only static instances can be accessed by static classes.
    private int score;
    private int kills;
    private int attempts;

    public Text scoreText;
    public Text killCount;
    public Text totalAttempts;


    private Scoreboard(){
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
        killCount = GameObject.FindWithTag("Kills").GetComponent<Text>();
        totalAttempts = GameObject.FindWithTag("Attempts").GetComponent<Text>();
    }

    public static Scoreboard GetInstance()  //this is a static method that returns the instance of the class
    {
        if (instance == null)
        {
            instance = new Scoreboard();
        }
        return instance;
    }

    //___________________________________________//
    
    public void addScore(int score)
    {
        this.score += score;
        
        scoreText.text = "Score: " + this.score;
       // Debug.Log("Score: " + this.score);

    }

    public void addKill()
    {
        this.kills++;
       // Debug.Log("Kills: " + this.kills);
        killCount.text = "Kills: " + this.kills;
    }

    public void addAttempt()
    {
        this.attempts++;
        //Debug.Log("Attempts: " + this.attempts);
        totalAttempts.text = "Attempts: " + this.attempts;
    }

    //__________________________________________//
    public int getScore()
    {
        return score;
    }
     public int getKills()
    {
        return kills;
    }
    public int getAttempts()
    {
        return attempts;
    }
}

