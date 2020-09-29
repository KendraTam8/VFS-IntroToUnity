using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnHit : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;


    private void OnCollisionEnter(Collision other)
    {
        _AudioSource.Stop();
        _AudioSource.Play();
    }
}