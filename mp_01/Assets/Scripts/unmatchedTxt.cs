using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unmatchedTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 0.5f);
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
