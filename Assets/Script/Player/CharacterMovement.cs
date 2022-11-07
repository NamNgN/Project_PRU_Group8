using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator am;
    private SpriteRenderer sprite;
    private float horizontalMove;
    bool isRolling;
    bool canRoll = true;
    private float rollDir = 1;
    private float rollingTime = 0.4f;
    private float rollingCoolDown = 1f;
    public float JumpTimerCounter;
    public float jumpTime;
    private bool isJump;
    private float jump = 0;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchGround;

    [HideInInspector] public bool isRight = true;


    [SerializeField] public float speed = 7f;
    [SerializeField] private float rollingSpeed = 21f;
    [SerializeField] private float jumpspeed = 12f;

    [Header("Jump")]
    //audio
    [SerializeField] private AudioClip jumpSoundEffect;
    //[Header("Move")]
    //[SerializeField] private AudioClip WalkingSE;


    private enum MovementState { idle, running, jumping, falling, rolling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame

    void Update()
    {
        isTouchGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        if (horizontalMove != 0)
        {
            rollDir = horizontalMove;
        }
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        jump = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Jump(jump);
        if (CrossPlatformInputManager.GetButtonDown("Roll") && canRoll == true && rb.velocity.y == 0)
        {
            if (Roll() != null)
            {
                StopCoroutine(Roll());
            }
            StartCoroutine(Roll());
        }
        UpdateAnimationState();
    }

    public float Jump( float jump)
    {
        if (isTouchGround==true && jump > 0)
        {
            SoundManager.instance.PlaySound(jumpSoundEffect);
            isJump = true;
            JumpTimerCounter = jumpTime;
            rb.velocity = Vector2.up * jumpspeed;
        }
        if (jump > 0 && isJump == true)
        {
            if (JumpTimerCounter > 0)
            {
               
                rb.velocity = Vector2.up * jumpspeed;
                JumpTimerCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }
        else if (jump == 0)
        {
            isJump = false;
        }
        return 1;
    }

    private IEnumerator Roll()
    {
        isRolling = true;
        canRoll = false;
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        yield return new WaitForSeconds(rollingCoolDown);
        canRoll = true;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isRolling)
        {
            if (rollDir < 0 && rb.velocity.x < 0f)
            {
                state = MovementState.rolling;
                sprite.flipX = true;
            }
            else if (rollDir > 0 && rb.velocity.x > 0f)
            {
                state = MovementState.rolling;
                sprite.flipX = false;
            }
            else
            {
                state = MovementState.idle;
            }
            am.SetInteger("state", (int)state);
        }
        else
        {

            if (horizontalMove < 0f)
            {
                
                isRight = false;
                state = MovementState.running;
                sprite.flipX = true;

            }

            else if (horizontalMove > 0f)
            {
               
                isRight = true;
                state = MovementState.running;
                sprite.flipX = false;
            }
            else
            {
                state = MovementState.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -1f)
            {
                state = MovementState.falling;
            }

            am.SetInteger("state", (int)state);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

       
        if (isRolling)
        {
            rb.AddForce(new Vector2(rollDir * rollingSpeed, 0), ForceMode2D.Impulse);
        }
    }
}
