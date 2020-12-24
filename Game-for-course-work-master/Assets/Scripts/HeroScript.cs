using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    //speed
    public float speed = 10f;
    public float YSpeed;

    //one jump and check on ground
    bool grounded = false;
    public Transform GroundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    //move true face
    bool facingRight = true;

    //Spawn
    float PosX, PosY;

    //Animator
    private Animator animator;
    //Ladder animation
    bool IsLadder = false;
    public LayerMask whatIsLadder;

    //Inicilizing Hero
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        PosX = rigid.position.x;
        PosY = rigid.position.y;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigid.AddForce(new Vector2(0, 150f));
        }

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, whatIsGround);
        IsLadder = Physics2D.OverlapCircle(GroundCheck.position, 0f, whatIsLadder);

        /////////////////////////
        YSpeed = rigid.velocity.y;
        ////////////////////////
        float move;
        move = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);

        //Check Flip facing
        if (move < 0 && facingRight)
            Flip();
        else if (move > 0 && !facingRight)
            Flip();

        //Action on ground or not
        if (grounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(move));
            animator.SetBool("OnGround", true);
        }
        else
        { 
            animator.SetFloat("YSpeed", rigid.velocity.y);
            animator.SetBool("OnGround", false);
        }

        if(IsLadder)
        {
            animator.SetBool("OnLadder", true);
        }
        else 
        {
            animator.SetBool("OnLadder", false);
        }
    }

    //Right or left face hero
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *=-1;
        transform.localScale = theScale;
    }

    //DethZone
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeathZone")
            rigid.position = new Vector2(PosX, PosY);
    }

}
