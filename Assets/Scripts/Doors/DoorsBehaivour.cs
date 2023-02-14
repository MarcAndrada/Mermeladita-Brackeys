using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehaivour : MonoBehaviour
{
    private BoxCollider2D door;
    private Animator doorAnimator;
    private void Awake()
    {
        door= GetComponent<BoxCollider2D>(); 
        doorAnimator = GetComponent<Animator>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            doorAnimator.SetBool("isDeath", true);
        }
    }
}
