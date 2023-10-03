using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    //references
    Rigidbody2D myBody;
    SpriteRenderer myRenderer;
    Transition myScript;
    
    [SerializeField] GameObject myObject;
    public GameObject deadPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myScript = myObject.GetComponent<Transition>();

   }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "KillGround")
        {
            Instantiate(deadPlayer, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            myScript.names = "Main";
            myScript.transStart = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "StoneDoor")
        {
            myScript.names = "Game2";
            myScript.transStart = false;
            myBody.bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.name == "StoneDoor1")
        {
            myScript.names = "Win";
            myScript.transStart = false;
            myBody.bodyType = RigidbodyType2D.Static;
        }
    }
}
