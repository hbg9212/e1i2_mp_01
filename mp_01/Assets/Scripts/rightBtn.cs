using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightBtn : MonoBehaviour
{
    public GameObject kms;
    public GameObject smg;
    public GameObject hbg;
    public GameObject rightBtnA;
    public GameObject leftBtnA;
    public int page = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage()
    {
        switch(page) 
        {
            case 0:
                rightBtnA.SetActive(true);
                leftBtnA.SetActive(false);
                hbg.SetActive(true);
                kms.SetActive(false);
                smg.SetActive(false);
                break;
            case 1:
                leftBtnA.SetActive(true);
                hbg.SetActive(false);
                kms.SetActive(true);
                smg.SetActive(false);
                break;
               
            case 2:
                hbg.SetActive(false);
                kms.SetActive(false);
                smg.SetActive(true);
                rightBtnA.SetActive(false);
                leftBtnA.SetActive(true);
                break;
        }
    }

    public void rightBt()
    {

        Debug.Log(page);
        page += 1;
        ChangePage();

    }

    public void leftBt()
    {

        Debug.Log(page);
        page -= 1;
        ChangePage();

    }
}
