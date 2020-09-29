using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticleOnHit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ParticleSystem;


    private void OnCollisionEnter(Collision other)
    {
        _ParticleSystem.Play();
    }
}