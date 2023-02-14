using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int startDir;
    private int coolDownTurn = 100;
    private bool startCoolDown = false;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private Animator _anim;

    [SerializeField]
    private float _velocity;

    [SerializeField]
    private Transform viewPoint;

    [SerializeField]
    private Transform[] groundCheckerPos;

    [SerializeField]
    private float length;

    [SerializeField]
    private float lenghtGroundChecker;

    [SerializeField]
    private LayerMask WallsLayer;

    [SerializeField]
    private LayerMask PlayerLayer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        startDir = UnityEngine.Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundChecker;
        RaycastHit2D groundChecker2;
        groundChecker = Physics2D.Raycast(groundCheckerPos[0].position, Vector2.down, lenghtGroundChecker, WallsLayer);
        groundChecker2 = Physics2D.Raycast(groundCheckerPos[1].position, Vector2.down, lenghtGroundChecker, WallsLayer);
        if (groundChecker.collider == null || groundChecker2.collider == null)
        {
            _rb.velocity = new Vector3(0, 0, 0);
            // DISPARAR
        }
        else
        {
            //_anim.SetBool("Stop", false);
            if (startDir == 0)
            {
                _rb.velocity = new Vector2(_velocity, _rb.velocity.y);
                _sp.flipX = true;
            }

            else if (startDir == 1)
            {
                _sp.flipX = false;
                _rb.velocity = new Vector2(-_velocity, _rb.velocity.y);
            }

            RaycastHit2D hit;
            hit = Physics2D.Raycast(viewPoint.position, Vector2.right, length, WallsLayer);
            if (hit.collider != null && startDir == 1 && startCoolDown == false)
            {
                _sp.flipX = true;
                startDir = 0;
                startCoolDown = true;
            }

            else if (hit.collider != null && startDir == 0 && startCoolDown == false)
            {
                _sp.flipX = false;
                startDir = 1;
                startCoolDown = true;
            }

            if (startCoolDown == true)
            {
                coolDownTurn--;

                if (coolDownTurn <= 0)
                {
                    startCoolDown = false;
                    coolDownTurn = 100;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(groundCheckerPos[0].position, groundCheckerPos[0].position + Vector3.down * lenghtGroundChecker);
        Debug.DrawLine(groundCheckerPos[1].position, groundCheckerPos[1].position + Vector3.down * lenghtGroundChecker);
        Debug.DrawLine(viewPoint.position, viewPoint.position + Vector3.right * length);
    }
}
