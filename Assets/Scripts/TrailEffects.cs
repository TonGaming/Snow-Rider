using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem TrailEffect;
    [SerializeField] AudioSource TrailSound;
    [SerializeField] AudioClip SnowStep;
    void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(SnowStep, 0.5f) ;
        // PLaying Audio when touched the ground
        TrailSound.Play();
        TrailEffect.Play();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        TrailSound.Stop();
        TrailEffect.Stop();
    }
}
