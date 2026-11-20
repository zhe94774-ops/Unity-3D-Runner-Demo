using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioSource[] soundEffects;
    public static Audiomanager instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void PlaySfx(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
}
