using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    SpriteRenderer playerSprite;
    
    public float speed, jumpforce;
    private float moveinput;
    private Rigidbody2D rb;

    private bool facingRight;

    public bool isGrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extrajumpValue;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        extraJump = extrajumpValue;
    }

    private void Update()
    {
        if (isGrounded == true)
            extraJump = extrajumpValue;

        if(Input.GetKeyDown(KeyCode.W) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);


        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);

        if (facingRight == false && moveinput > 0)
        {
            playerSprite.flipX = true;
            facingRight = !facingRight;
        }
        else if (facingRight == true && moveinput < 0)
        {
            playerSprite.flipX = false;
            facingRight = !facingRight;
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        /*Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;*/

        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>() ;
        playerSprite.flipX = true;

    }
}
