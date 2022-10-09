using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ScoreManager
{
       private int score;
       private int kills;
       private int attempts;

       public Text scoreText;
       public Text killCount;
       public Text TotalAttempts;

       private ScoreManager()
       {
        scoreText =GameObject.FindWithTag("Score").GetComponent<Text>();
        killCount =GameObject.FindWithTag("Kills").GetComponent<Text>();
        TotalAttempts =GameObject.FindWithTag("Attempts").GetComponent<Text>();
       }

        //_______________________________________________________________//
       private static ScoreManager instance;
       public static ScoreManager GetInstance()
       {
               if(instance == null)
               {
                   instance = new ScoreManager();
               }
               return instance;
           
       }
       //_______________________________________________________________//


         public void AddScore(int score)
         {
            this.score += score;
            scoreText.text = "Score: " + this.score;
         }
         public void AddKill()
         {
            this.kills++;
            killCount.text = "Kills: " + this.kills;
         }
         public void AddAttempt(int att)
         {
            this.attempts += att;
            TotalAttempts.text = "Attempts: " + this.attempts;   
         }

        //_______________________________________________________________//

            public int GetScore()
            {
                return score;
            }
            public int GetKills()
            {
                return kills;
            }
            public int GetAttempts()
            {
                return attempts;
            }
       
       
        public void ResetScore()
        {
            score = 0;
            kills = 0;
            attempts = 0;
            scoreText.text = "Score: " + score;
          s  killCount.text = "Kills: " + kills;
            TotalAttempts.text = "Attempts: " + attempts;
        }
}
