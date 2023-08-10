using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class panel : MonoBehaviour
{
    public Text bestScore;
    public Text nowScore;

    void Start()
    {


    }

    public void bestScoreSet(string name)
    {
        bestScore.text = name;
    }
    public void nowScoreSet(string name)
    {
        nowScore.text = name;
    }

    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void goBack()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
