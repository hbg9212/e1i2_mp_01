using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressTheScreen : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressThesScreen()
    {
        gameObject.SetActive(false);
        anim.SetBool("press", true);
    }
}
