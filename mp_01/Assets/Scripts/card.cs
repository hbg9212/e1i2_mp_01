using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public AudioClip flip;
    public AudioSource audioSource;
    float time = 0.0f;
    bool firstCardselect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(firstCardselect)
        {
            if(time >= 3.0f)
            {
                firstCardselect = false;
                gameManager.I.firstCard = null;
                Invoke("closeCardInvoke", 0.0f);
            }
        }
    
    }

    public Animator anim;

    public void openCard()
    {
        audioSource.PlayOneShot(flip);

        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
            time = 0.0f;
            firstCardselect = true;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
            time = 0.0f;
            firstCardselect = false;
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.5f);
        firstCardselect = false;
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
        firstCardselect = false;
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 0.5f);
        firstCardselect = false;
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        firstCardselect = false;
    }

}
