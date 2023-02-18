using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlayerData")]
public class PlayerData : ScriptableObject {

    [Header("Horizontal Movement")]
    public float runMaxSpeed;
    public float runAccel;
    public float runDeccel;

    public float runAccelAmount;
    public float runDeccelAmount;
    [Range(0f, 1)] public float accelInAir; 
    [Range(0f, 1)] public float deccelInAir;

    [Header("Vertical Movement")]
    public float jumpHeight;
    public float jumpTimeToApex;
    public float jumpCutGravityMult;

    public float jumpForce;

    [Range(0.01f, 0.5f)] public float coyoteTime;
    [Range(0.01f, 0.5f)] public float jumpInputBufferTime;

    [Header("Gravity")]
    public float fallGravityMult;
    public float maxFallSpeed;
    public float fastFallGravityMult;
    public float maxFastFallSpeed;

    [HideInInspector] public float gravityStrength;
    [HideInInspector] public float gravityScale;

    [Header("Slide")]
    public float slideSpeed;
    public float slideAccel;
    private void OnValidate() {
        gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);

        gravityScale = gravityStrength / Physics2D.gravity.y;

        runAccelAmount = (50 * runAccel) / runMaxSpeed;
        runDeccelAmount = (50 * runDeccel) / runMaxSpeed;

        jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;

        runAccel = Mathf.Clamp(runAccel, 0.01f, runMaxSpeed);
        runDeccel = Mathf.Clamp(runDeccel, 0.01f, runMaxSpeed);
    }
}
