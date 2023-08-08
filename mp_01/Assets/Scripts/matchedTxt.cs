using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchedTxt : MonoBehaviour
{
    public Text text;

    void Start()
    {
        
        Invoke("destroy", 0.5f);
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    public void nameSet(string name)
    {
        text.text = name;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
