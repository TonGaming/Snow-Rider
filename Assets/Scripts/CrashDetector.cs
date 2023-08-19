using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem CrashEffect;
    bool hasCrashed = false;
    [SerializeField] AudioClip CrashSFX;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (!hasCrashed)
        {
            hasCrashed = true;
            GetComponent<AudioSource>().PlayOneShot(CrashSFX,0.5f);
            // chạy âm thanh vỡ đầu
            CrashEffect.Play();
            // Khoá controls khi va chạm
            FindObjectOfType<PlayerController>().DisableControls();
        }
        Invoke("reloadScene", delayTime);
    }

    void reloadScene()
    {
        SceneManager.LoadScene("Level1");
        
    }
}
