using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sp;
    private Animator _anim;
    private bool startCoolDown;
    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        coolDown = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && startCoolDown == false)
        {
            _anim.SetBool("Attack", true);
            startCoolDown = true;
        }     

        if(startCoolDown == true)
        {
            coolDown--;
        }

        if(coolDown <= 0)
        {
            startCoolDown = false;
            _anim.SetBool("Attack", false);
            coolDown = 50;
        }
    }
}
