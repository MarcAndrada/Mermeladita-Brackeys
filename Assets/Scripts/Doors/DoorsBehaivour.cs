using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehaivour : MonoBehaviour
{
    
    private enum DoorType { GREEN, RED, BLUE};
    [SerializeField]
    DoorType type;
    [SerializeField]
    private BoxCollider2D door;
    private Animator doorAnimator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();   
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    private void Start()
    {
        switch (type)
        {
            case DoorType.GREEN:
                spriteRenderer.color = Color.green;
                break;
            case DoorType.RED:
                spriteRenderer.color = Color.red;
                break;
            case DoorType.BLUE:
                spriteRenderer.color = Color.blue;
                break;
            default:
                break;
        }
    }
    private void CheckCanOpen()
    {
        switch (type)
        {
            case DoorType.GREEN:
                
                break;
            case DoorType.RED:
         
                break;
            case DoorType.BLUE:
          
                break;
            default:
                break;
        }
    }

    private void DoorOpen()
    {
        doorAnimator.SetBool("isDeath", true);
        door.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CheckCanOpen();
        }
    }
}
