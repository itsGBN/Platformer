using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour    
{
    //referneces
    Rigidbody2D myBody;
    Animator myAnim;
    SpriteRenderer myRenderer;

    //variables
    float horizontalMove;
    public float speed = 2f;
    bool grounded = false;
    public float castDist = 1f;
    public float jumpPower = 2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            myAnim.SetBool("jumping", true);
            jump = true;
        }

        if (horizontalMove >= 0.5f || horizontalMove <= -0.5f)
        {
            myAnim.SetBool("running", true);
            if (horizontalMove >= 0.5) { myRenderer.flipX = false; }
            if (horizontalMove <= -0.5) { myRenderer.flipX = true; }
        }
        else
        {
            myAnim.SetBool("running", false);
        }
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if (myBody.velocity.y > 0f)
        {
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0f)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if(hit.collider != null && hit.transform.tag == "Ground")
        {
            myAnim.SetBool("jumping", false);
            grounded = true;
        }
        else
        {
            myAnim.SetBool("jumping", true);
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f);

    }
}
