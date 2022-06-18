using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class move_player : MonoBehaviour
{

    public float move_speed;
    public float jumpforce;
    public float doubleJumpForce; 

    public bool isJump = false;
    public bool doubleJump = false;
    public bool isGround;

    public Transform left;
    public Transform right; 

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public CapsuleCollider2D playerCollider;
    public Animator animator;
    public SpriteRenderer sprite;

    public static move_player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de PlayerMovement dans la sc�ne");
            return;
        }
        instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)&& isGround)
        { 
                isJump = true; 
        }
        if(Input.GetKeyDown(KeyCode.Z)&& isGround)
        {
                doubleJump = true;
        }
             
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapArea(left.position, right.position); 
        float horizontalMove = Input.GetAxis("Horizontal") * move_speed * Time.fixedDeltaTime;
        move_Player(horizontalMove);
    }

    void move_Player(float _horizontalMove)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJump)
        {
           Jump( jumpforce); 
            isJump = false ;
        }
        if (doubleJump)
        {
           Jump( doubleJumpForce);
            doubleJump = false;
        }
    }

    void Jump(float jump)
    {
        rb.AddForce(new Vector2(0f, jump));
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (_velocity < 0.1f)
        {
            sprite.flipX = true;
        }
    }
}
