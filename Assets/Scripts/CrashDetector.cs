using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem CrashEffect;
    bool isFirstCrashed = true;
    [SerializeField] AudioClip CrashSFX;
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (isFirstCrashed)
        {
            GetComponent<AudioSource>().PlayOneShot(CrashSFX, 0.5f);
            CrashEffect.Play();
            isFirstCrashed = false;
        }
        Invoke("reloadScene", delayTime);
    }

    void reloadScene()
    {
        SceneManager.LoadScene("Level1");
        
    }
}
