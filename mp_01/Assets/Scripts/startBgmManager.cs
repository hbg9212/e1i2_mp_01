using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBgmManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startBgm;
    // Start is called before the first frame update

    private void Awake()
    {
        var obj = FindObjectsOfType<startBgmManager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource.clip = startBgm;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenCheck();
    }

    public void ScreenCheck()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Destroy(gameObject);
        }
    }

}
