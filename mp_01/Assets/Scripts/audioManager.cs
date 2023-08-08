using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip bgmIdle;
    public AudioClip bgmImminent;

    bool imminent = false;

    // Start is called before the first frame update
    void Start()
    {
        imminent = true;
        audioSource.clip = bgmIdle;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.I.time <= 10.0f && gameManager.I.time > 0.0f && imminent)
        {
            bgmMminentPlay();
        }

    }

    public void bgmMminentPlay()
    {
        audioSource.clip = bgmImminent;
        audioSource.Play();
        imminent = false;
    }
}
