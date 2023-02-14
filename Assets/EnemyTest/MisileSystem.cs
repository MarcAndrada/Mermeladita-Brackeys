using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class MisileSystem : ShootingSystem
{
    private GameObject objective;

    private float shootCoolDown = 0;
    private bool startCoolDown = false;

    private float distance;
    private float distance2;
    
    private bool playerDetection;

    Vector3 shootDir;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            playerDetection = false;
        }
    }

    private void Update()
    {
        if(playerDetection)
        {
            Shoot();
        }

        if(startCoolDown)
        {
            shootCoolDown-= Time.deltaTime;
        }

        if(shootCoolDown <= 0)
        {
            startCoolDown = false;
        }
    }

    public override void Shoot()
    {
        if(shootCoolDown <= 0)
        {
            var mis = Instantiate(shootingdata.projectile, shotPoint.position, shotPoint.rotation);
            objective = GameObject.FindGameObjectWithTag("Player");
            distance2 = Vector3.Distance(mis.transform.position, objective.transform.position);

            shootDir = objective.transform.position - mis.transform.position;

            mis.GetComponent<Rigidbody2D>().velocity = shootDir * shootingdata.fireForce;

            shootCoolDown = 1;
            startCoolDown = true;
        }
    }
}*/
