using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    public Text ezScore;
    public Text normalScore;
    public Text hardScore;

    public GameObject noClear; 

    // Start is called before the first frame update
    void Start()
    {
 
        if (PlayerPrefs.HasKey("ezScore") != false)
        {
            ezScore.text = PlayerPrefs.GetInt("ezScore").ToString();
        }
        if (PlayerPrefs.HasKey("normalScore") != false)
        {
            normalScore.text = PlayerPrefs.GetInt("normalScore").ToString();
        }
        if (PlayerPrefs.HasKey("hardScore") != false)
        {
            hardScore.text = PlayerPrefs.GetInt("hardScore").ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEz()
    {
        SceneManager.LoadScene("MainScene");
        PlayerPrefs.SetInt("level", 0);

    }

    public void startNormal()
    {
        if(PlayerPrefs.HasKey("ezScore") == false)
        {
            GameObject noClearTxt = Instantiate(noClear);
            noClearTxt.transform.parent = GameObject.Find("Back").transform;
            noClearTxt.GetComponent<noClear>().nameSet("쉬움 난이도를 먼저 클리어 하세요.");
            noClearTxt.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            SceneManager.LoadScene("MainScene");
            PlayerPrefs.SetInt("level", 1);
        }


    }

    public void startHard()
    {
        if (PlayerPrefs.HasKey("normalScore") == false)
        {
            GameObject noClearTxt = Instantiate(noClear);
            noClearTxt.transform.parent = GameObject.Find("Back").transform;
            noClearTxt.GetComponent<noClear>().nameSet("보통 난이도를 먼저 클리어 하세요.");
            noClearTxt.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            SceneManager.LoadScene("MainScene");
            PlayerPrefs.SetInt("level", 2);
        }

    }
}
