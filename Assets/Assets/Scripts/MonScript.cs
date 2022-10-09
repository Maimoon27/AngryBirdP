using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bird" || collision.gameObject.name=="Wooden Crate")
        {
                Scoreboard.GetInstance().addScore(10);
                Scoreboard.GetInstance().addKill();
                Destroy(gameObject);

        }
                   
    }
    
}
