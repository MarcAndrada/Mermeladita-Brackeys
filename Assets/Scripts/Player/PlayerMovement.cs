using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour {


    public PlayerData data;

    [SerializeField] private Rigidbody2D rb2d;

    // Variables de control
    public bool IsFacingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsSliding { get; private set; }
    // Timers
    public float LastOnGroundTime { get; private set; }

    // Jump
    public float LastPressedJumpTime { get; private set; }

    [Header("Inputs")]
    private Vector2 moveInput;

    [Header("Jump")]
    [SerializeField] private bool isJumpCut;
    [SerializeField] private bool isJumpFalling;

    [Header("Colisions")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.03f);
    [SerializeField] private LayerMask groundLayer;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        SetGravityScale(data.gravityScale);
        IsFacingRight = true;
    }

    private void Update() {
        LastOnGroundTime -= Time.deltaTime;
        LastPressedJumpTime -= Time.deltaTime;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.x > 0 && !IsFacingRight) { 
            Flip();
        }
        if (moveInput.x < 0 && IsFacingRight) {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            OnJumpInput();
        } 
        if (Input.GetKeyUp(KeyCode.Space)) { 

            OnJumpUpInput();
        }

        // Colision Check
        if (!IsJumping) {
            if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer) && !IsJumping) {
                LastOnGroundTime = data.coyoteTime;
            }
        }
        if(IsJumping && rb2d.velocity.y < 0) {
            IsJumping = false;
            isJumpFalling = true;
        }
        if (LastOnGroundTime > 0 && !IsJumping) {
            isJumpCut = false;
            
            if (!IsJumping) {
                isJumpFalling = false;
            }
        }
        if (CanJump() && LastPressedJumpTime > 0) {
            IsJumping = true;
            isJumpCut = false;
            isJumpFalling = false;
            Jump();
        }

        if (rb2d.velocity.y < 0 && moveInput.y < 0) {
            SetGravityScale(data.gravityScale * data.fastFallGravityMult);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Max(rb2d.velocity.y, -data.maxFastFallSpeed));
        } else if (isJumpCut) {
            SetGravityScale(data.gravityScale * data.jumpCutGravityMult);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Max(rb2d.velocity.y, -data.maxFallSpeed));
        } else if (rb2d.velocity.y < 0) {
            SetGravityScale(data.gravityScale * data.fallGravityMult);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Max(rb2d.velocity.y, -data.maxFallSpeed));
        } else {
            SetGravityScale(data.gravityScale);
        }

        if (CanSlide() && (moveInput.x < 0 || moveInput.x > 0))
            IsSliding = true;
        else
            IsSliding = false;
    }

    private void FixedUpdate() {
        Movement(1);
        if (IsSliding)
            Slide();
    }

    public void SetGravityScale(float scale) {
        rb2d.gravityScale = scale;
    }

    public void OnJumpInput() {
        LastPressedJumpTime = data.jumpInputBufferTime;
    }
    public void OnJumpUpInput() {
        if (CanJumpCut()) {
            isJumpCut = true;
        }
    }
    public bool CanJump() {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    private bool CanJumpCut() {
        return IsJumping && rb2d.velocity.y > 0;
    }
    public bool CanSlide() {
        if (!IsJumping && LastOnGroundTime <= 0)
            return true;
        else
            return false;
    }
    void Movement(float lerpAmount) {
        float targetSpeed = moveInput.x * data.runMaxSpeed;
        targetSpeed = Mathf.Lerp(rb2d.velocity.x, targetSpeed, lerpAmount);

        float accelRate; 
        
        if (LastOnGroundTime > 0) { 
            if (Mathf.Abs(targetSpeed) > 0.01f) {
                accelRate = data.runAccel;
            } else {
                accelRate = data.runDeccel;
            }
        } else {
            if (Mathf.Abs(targetSpeed) > 0.01f) {
                accelRate = data.runAccel * data.accelInAir;
            }
            else {
                accelRate = data.runDeccel * data.deccelInAir;
            }
        }

        if (Mathf.Abs(rb2d.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb2d.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0) {
            accelRate = 0;
        }

        float speedDif = targetSpeed - rb2d.velocity.x;

        float movement = speedDif * accelRate;

        rb2d.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }
    void Jump() {
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        float force = data.jumpForce;

        if (rb2d.velocity.y < 0) {
            force -= rb2d.velocity.y;
        }

        rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    void Slide() {
        float speedDif = data.slideSpeed - rb2d.velocity.y;
        float movement = speedDif * data.slideAccel;

        movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif) * (1 / Time.deltaTime), Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

        rb2d.AddForce(movement * Vector2.up);
    }
    void Flip() {
        if (moveInput.x != 0) {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            IsFacingRight = !IsFacingRight;
        }
    }
}
