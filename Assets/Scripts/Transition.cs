using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    SpriteRenderer myRenderer;

    float xfloat = 1f;

    public bool transStart = false;

    public string names = "null";

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        transStart = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRenderer.color = new Color(0f, 0f, 0f, xfloat);
        if (transStart) 
        {
            if (xfloat >= 0f) xfloat -= 0.05f; 
        }

        else
        {
            if (xfloat <= 1f) xfloat += 0.01f;
            if (xfloat >= 1f) SceneManager.LoadScene(names);
        }
    }
}
