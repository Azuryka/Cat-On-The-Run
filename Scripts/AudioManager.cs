using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private AudioSource soundEffect;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private AudioClip[] sounds;

    [SerializeField]
    private AudioClip[] songs;

    private void Start()
    {
        if (gameManager.inGame)
        {
            music.clip = songs[0];
            music.Play();
        }
        else
        {
            music.clip = songs[1];
            music.Play();
        }
    }

    public void SEClick()
    {
        soundEffect.clip = sounds[0];
        soundEffect.Play();
    }

    public void SECatFood()
    {
        soundEffect.clip = sounds[1];
        soundEffect.Play();
    }

    public void SEFish()
    {
        soundEffect.clip = sounds[2];
        soundEffect.Play();
    }
}
