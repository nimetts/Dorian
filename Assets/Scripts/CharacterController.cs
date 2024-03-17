using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private Animator _animator;
    public float jumpSpeed = 10f, jumpFrequency = 1f, nextJump;
    private bool isGrounded = false;
    public bool facingRight = true;
    public Transform GroundPosition;

    public float GroundRadius;

    public LayerMask GroundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { OnGroundCheck();
        HorizontalMove();
        if (rb.velocity.x < 0 && facingRight )
        {
            FlipFace();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
         FlipFace();   
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJump<Time.timeSinceLevelLoad))
        {
            nextJump = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void HorizontalMove()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        _animator.SetFloat("playerSpeed",Mathf.Abs(rb.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 transLocale = transform.localScale;
        transLocale.x *= -1;
        transform.localScale = transLocale;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f,jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundPosition.position, GroundRadius, GroundLayer);
        _animator.SetBool("Jump",isGrounded);
    }
}
