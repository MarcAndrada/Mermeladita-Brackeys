using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotShoot : MonoBehaviour
{
    private float coolDownTurn = 0;
    private bool startCoolDown = false;
    private float _velocity;
    public Transform[] shotPoints;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    private Animator _anim;

    public Transform shotPoint;
    public Transform shotPoint2;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _rb.velocity = new Vector2(0, 0);
        _anim.SetBool("Stop", true);
        if(_sp.flipX == false)
        {
            shotPoint = shotPoints[0];
        }
        else if(_sp.flipX == true)
        {
            shotPoint = shotPoints[1];
        }
        
        if(startCoolDown == false && _sp.flipX == true)
        {
            //var shot = Instantiate(shootingdata.projectile, shotPoint.position, shotPoint.rotation);
            //shot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.right * shootingdata.fireForce);

            startCoolDown = true;
        }

        if (startCoolDown == false && _sp.flipX == false)
        {
            //var shot = Instantiate(shootingdata.projectile, shotPoint.position, shotPoint.rotation);
            //shot.GetComponent<Rigidbody2D>().AddForce(-shotPoint.transform.right * shootingdata.fireForce);

            startCoolDown = true;
        }

        if (startCoolDown == true)
        {
            coolDownTurn-= Time.deltaTime;

            if (coolDownTurn <= 0)
            {
                startCoolDown = false;
                coolDownTurn = 2;
            }
        }
    }
}
