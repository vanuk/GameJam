using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSounds : MonoBehaviour
{
 private AudioSource _audioSource;

 private void Start()
 {
     _audioSource = GetComponent<AudioSource>();
 }

 public void AudioSourcePlay()
 {
     _audioSource.Play();
 }
}
