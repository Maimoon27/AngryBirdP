using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour

{
    public Vector3 initPosc;
    public int Speed =500;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriterenderer;
    private bool IsBirdFired;
    private float BirdWaitingTime;
    private AudioManager audioManager;

    public void Awake()
    {
        initPosc = transform.position;
        spriterenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();

    }


   public void OnMouseDown()
   {
    spriterenderer.color = Color.red;
    audioManager.Play("Stretch");

    
   }


   public void OnMouseUp()
   {
    spriterenderer.color = Color.white;

    rigidbody2D.gravityScale = 1;

    Vector3 distance = initPosc - transform.position;

    rigidbody2D.AddForce(distance*Speed);
    IsBirdFired = true;
    audioManager.Play("Throw");

    Scoreboard.GetInstance().addAttempt();
    Scoreboard.GetInstance().addScore(-5);


   }


   public void OnMouseDrag()
   {
    Vector2 dragPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position=new Vector2(dragPos.x,dragPos.y);
   }

   public void Update()
   {

    if(IsBirdFired==true && rigidbody2D.velocity.magnitude <0.3)
    {
        BirdWaitingTime += Time.deltaTime;
    }
    if(BirdWaitingTime > 2)
    {
        reset();
    }
         if( GameObject.FindObjectsOfType<MonScript>().Length == 0)
         {
                SceneManager.LoadScene("Level2");

         }



    if (transform.position.x > 15 || transform.position.x < -15)
    {
        reset();
    }
    if (transform.position.y > 6 || transform.position.y < -6)
    {
        reset();    }
   }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Mons2" )
        {
            LevelManager.instance.LoadNextLevel();
        }
                   
    }

   public void reset(){
    transform.position = initPosc;
            
            transform.rotation = Quaternion.identity;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.angularVelocity = 0;
            rigidbody2D.gravityScale = 0;
            IsBirdFired = false;
            BirdWaitingTime = 0;
   }

}
