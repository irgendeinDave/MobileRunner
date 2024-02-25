using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    private static AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public static void muteAudio()
    {
        audio.mute = true;
    }

    public static void unmuteAudio()
    {
        audio.mute = false;
    }

    public static void setVolume(float vol)
    {
        audio.volume = vol;
    }
}
