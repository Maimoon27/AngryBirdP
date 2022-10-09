using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
 public Sound[] sounds;

 //public static AudioManager instance;
 public void Awake()
 {
    DontDestroyOnLoad(gameObject);
     foreach(Sound s in sounds)
     {
         s.audiosource = gameObject.AddComponent<AudioSource>();
         s.audiosource.clip = s.clip;
         s.audiosource.loop = s.loop;
         s.audiosource.volume = s.volume;
         s.audiosource.pitch = s.pitch;
     }
 }
 public void Play(string name)
 {
    foreach (Sound s in sounds)
    {
        if(s.name == name)
        {
            s.audiosource.Play();
        }
    }
}  
}
