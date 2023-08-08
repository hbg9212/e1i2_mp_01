using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager I;

    void Awake()
    {
        I = this;
    }

    public GameObject card;

    public float time = 0.0f;
    int count = 0;
    public Text countTxt;
    public Text idleText;
    public Text imminentText;
    public GameObject endTxt;

    string[] nameArray = { "k_", "h_", "s_" };
    string[] infoArray = { "0", "1", "2", "3", "4", "5" };
    string[] allCardName = new string[18];

    void AllCardShuffle()
    {
        int allCount = 0;
        for (int a=0; a< nameArray.Length; a++ )
        {
            for (int b = 0; b < infoArray.Length; b++)
            {
                allCardName[allCount++] = nameArray[a]+ infoArray[b];
            }
        }
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 60.0f;
        AllCardShuffle();
        Time.timeScale = 1.0f;

        string[] setCard = ShuffleArray(allCardName);
        setCard = setCard.Take(8).ToArray();
        setCard = setCard.Concat(setCard).ToArray();
        setCard = ShuffleArray(setCard);

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(0, y, 0);
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(setCard[i]);
           
            cardSet(newCard, x);
        }
    }

    void cardSet(GameObject card, float x)
    {
        card.transform.position += new Vector3(x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        countTxt.text = count.ToString();
        time -= Time.deltaTime;

        if (time > 10.0f)
        {
            idleText.text = time.ToString("N2");
            imminentText.text = "";

        }
        else if (time <= 10.0f && time > 0.0f)
        {
            idleText.text = "";
            imminentText.text = time.ToString("N2");
    
        }
        else if (time <= 0.0f)
        {
            imminentText.text = "0.00";
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public GameObject firstCard;
    public GameObject secondCard;

    public GameObject timeLoss;

    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip unMatch;
    public Text matchedTxt;
    public Text unmatchedTxt;
   

    bool matchB = true;
    bool unMatchB = true;

    public void isMatched()
    {

        count++;
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {

            if (firstCardImage.Substring(0, 1) == "h")
            {
                matchedTxt.text = "한병권";
            } 
            else if (firstCardImage.Substring(0, 1) == "k")
            {
                matchedTxt.text = "김명식";
            }
            else if (firstCardImage.Substring(0, 1) == "s")
            {
                matchedTxt.text = "송명근";
            }
            unmatchedTxt.text = "";

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
            if (matchB) Invoke("destroyMatchedTxtInvoke", 1.0f);
            audioSource.PlayOneShot(match);
            matchB = false;
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            unmatchedTxt.text = "실패";
            matchedTxt.text = "";
            GameObject timeLossTxt = Instantiate(timeLoss);
            timeLossTxt.transform.parent = GameObject.Find("top").transform;
            timeLossTxt.transform.position = new Vector3(0, 520, 0);
            audioSource.PlayOneShot(unMatch);

            time--;
            if(unMatchB) Invoke("destroyUnmatchedTxtInvoke", 1.0f);
            unMatchB = false;
        }

        firstCard = null;
        secondCard = null;
    }

    void destroyMatchedTxtInvoke()
    {
        matchedTxt.text = "";
        matchB = true;
    }
    void destroyUnmatchedTxtInvoke()
    {
        unmatchedTxt.text = "";
        unMatchB = true;
    }
}
