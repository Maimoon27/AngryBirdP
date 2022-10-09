using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager2 : MonoBehaviour
{
   public Sound2[] sounds2;

   public static AudioManager2 instance; //to make to singleton

   public void Awake()
   {
      //------------------------------------------------------------//
      if(instance == null)    //if condition for singleton class
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
         return;
      }
   //--------------------------------------------------------------//

      DontDestroyOnLoad(gameObject);

       foreach (Sound2 s in sounds2)
       {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
       }

      
   }
    public void PlayMySound2(string name)
       {
           foreach(Sound2 s in sounds2)
           {
            if(s.name==name)
            {
               s.source.Play();
            }
           }
       }
   
}
