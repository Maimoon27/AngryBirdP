using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript2 : MonoBehaviour
{
    public Vector3 initialPos;
    public int Speed = 500;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private bool IsBirdFired;
    private float BirdWaitingTime;
    private AudioManager2 am2;


//_______________________________________________________________//
    public void Awake()
    {
        initialPos =transform.position;
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        am2 =FindObjectOfType<AudioManager2>();
    } 

//_______________________________________________________________//
    public void OnMouseDown()
    {
        sr.color = Color.black;
        am2.PlayMySound2("Pull");
    }

//_______________________________________________________________//
    private void OnMouseUp()
    {
        sr.color = Color.white;
        rb2d.gravityScale = 1;
        Vector3 distance = initialPos -transform.position;
        rb2d.AddForce(distance * Speed);
        IsBirdFired = true;
        am2.PlayMySound2("Throw2");
        ScoreManager.GetInstance().AddAttempt(1);
        ScoreManager.GetInstance().AddScore(-5);
                

    }

//_______________________________________________________________//
    public void OnMouseDrag()
    {
        Vector2 dragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(dragPos.x, dragPos.y);
    }

//_______________________________________________________________//
    void Update()
    {
        if(IsBirdFired==true && rb2d.velocity.magnitude <= 0.3)
        {
            BirdWaitingTime += Time.deltaTime;
        }
        if(BirdWaitingTime >= 2)
        {
            reset();
        }
        if(GameObject.FindObjectsOfType<MonsterS>().Length == 0)
        {
            SceneManager.LoadScene("Level1");
        }
        if(transform.position.x <= -9.5 || transform.position.x >= 9.5 )
        {
            reset();
        }
        if( transform.position.y <= -5.5 || transform.position.y >= 5.5)
        {
            reset();
        }

        if(GameObject.FindObjectsOfType<MonsterS>().Length == 0)
        {
            SceneManager.LoadScene("Level2");
            ScoreManager.GetInstance().ResetScore();
        }
    }

//_______________________________________________________________//
public void reset()
{
    transform.position = initialPos;
    transform.rotation = Quaternion.identity;
    rb2d.velocity = Vector2.zero;
    rb2d.angularVelocity = 0;
    rb2d.gravityScale = 0;
    IsBirdFired=false;
    BirdWaitingTime = 0;
}
//______________________________________________________________//

public void OnCollisionEnter2D(Collision2D collision)
  {
    
    if (collision.gameObject.tag == "Crate")
    {
        am2.PlayMySound2("Hitc");
    }
  }
}
