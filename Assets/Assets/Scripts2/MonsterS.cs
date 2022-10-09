using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterS : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D collision)
  {
   
        
    if (collision.gameObject.tag == "Bird"||transform.position.x >= 9.5)
    {
        FindObjectOfType<AudioManager2>().PlayMySound2("Hitm");
        ScoreManager.GetInstance().AddScore(10);
        ScoreManager.GetInstance().AddKill();
        Destroy(gameObject);
        // print(ScoreManager.GetInstance().GetScore());
        // print(ScoreManager.GetInstance().GetKills());
        // print(ScoreManager.GetInstance().GetAttempts());
    }
     
  }

    // Update is called once per frame
}
