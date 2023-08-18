using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem CrashEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        CrashEffect.Play();
        Invoke("reloadScene", delayTime);
    }

    void reloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
