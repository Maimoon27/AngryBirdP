using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mons2 : MonoBehaviour

{
    private AudioManager audioManager;

    public void Awake()
{
    audioManager = FindObjectOfType<AudioManager>();
}
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
            audioManager.Play("attack");

        if(collision.gameObject.name == "Bird" )
        {
                Destroy(gameObject);
        }
        
    }
}
