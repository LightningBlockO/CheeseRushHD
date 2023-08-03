using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseAudio : MonoBehaviour
{
    private AudioSource cheeseAudioSource;

    private void Start()
    {
        cheeseAudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if (cheeseAudioSource != null)
        {
            cheeseAudioSource.Play();
        }
    }
}
