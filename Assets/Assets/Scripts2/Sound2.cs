using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Sound2
{
   public string name;
   public AudioClip clip;

    public bool loop;
    [Range(0.1f,3f)]
    public float volume;

    [Range(0f,1f)]
    public float pitch;
    

    [HideInInspector]
    public AudioSource source;

}
