using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
}
