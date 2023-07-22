using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundAndMusicButtons : MonoBehaviour
{
    private Toggle button => this.GetComponent<Toggle>();
    private AudioMixerGroup mixer;
    private void OnEnable()
    {
        
    }
}
