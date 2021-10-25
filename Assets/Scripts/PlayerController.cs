using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float BASE_SPEED = 5;
    Rigidbody2D rb;
    [SerializeField] private float JUMP_FORCE = 5f;
    float currentSpeed;
    public Animator animator;

    private bool isGrounded = false;

    bool canDoubleJump;

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", !isGrounded);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = BASE_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, 0);

        rb.velocity = new Vector2((dir * currentSpeed).x, rb.velocity.y);

        //Flip Player Sprite
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -5;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 5;
        }
        transform.localScale = characterScale;

        //jumping
        if (vertical > 0 && Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.AddRelativeForce(new Vector2(0, JUMP_FORCE), ForceMode2D.Impulse);
            canDoubleJump = true;
        }
        //Double Jump
        if(vertical > 0 && rb.velocity.y < 0 && canDoubleJump)
        {
            rb.AddRelativeForce(new Vector2(0, JUMP_FORCE), ForceMode2D.Impulse);
            canDoubleJump = false;
        }

        //Walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Jumping Animation
        if (Mathf.Abs(rb.velocity.y) > 0)
        {
            animator.SetBool("Jump", true);
        }

        animator.SetFloat("yVelocity", rb.velocity.y);

    }
}
