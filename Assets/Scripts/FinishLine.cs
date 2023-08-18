using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// acessing an unity library
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("reloadScene", delayTime);
        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene("Level1");
    }


}

