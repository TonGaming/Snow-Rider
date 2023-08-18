using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffects : MonoBehaviour
{

    [SerializeField] ParticleSystem TrailEffect;
    [SerializeField] AudioSource TrailSound;
   
    void OnCollisionEnter2D(Collision2D other)
    {
        TrailSound.Play();
        TrailEffect.Play();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        TrailSound.Stop();
        TrailEffect.Stop();
    }
}
