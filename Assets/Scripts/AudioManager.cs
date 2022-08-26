using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource fxAudioSource;
    public AudioSource winPuzzleAudioSource;
    public AudioClip[] fxClips;
    
    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void PlayAudio(AudioClip audioClip, bool shouldLoop)
    {
        audioSource.Stop();
        audioSource.loop = shouldLoop;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void PlayRandomRepairFX()
    {
        int randomInt = Random.Range(0, fxClips.Length);
        fxAudioSource.clip = fxClips[randomInt];
        fxAudioSource.Play();
    }

    public void PlayWinPuzzleAudio()
    {
        winPuzzleAudioSource.Play();
    }

}
