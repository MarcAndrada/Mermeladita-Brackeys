using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehaivour : MonoBehaviour
{
    
    public enum ColorType { GREEN, RED, BLUE};
    [SerializeField]
    ColorType type;
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
            case ColorType.GREEN:
                spriteRenderer.color = Color.green;
                break;
            case ColorType.RED:
                spriteRenderer.color = Color.red;
                break;
            case ColorType.BLUE:
                spriteRenderer.color = Color.blue;
                break;
            default:
                break;
        }
    }
    private void CheckCanOpen(PlayerKeysController _playerKeys)
    {
        switch (type)
        {
            case ColorType.GREEN:
                if (_playerKeys.keyGreen)
                {
                    DoorOpen();
                    _playerKeys.keyGreen = false;
                }
                break;
            case ColorType.RED:
                if (_playerKeys.keyRed)
                {
                    DoorOpen();
                    _playerKeys.keyRed = false;
                }
                break;
            case ColorType.BLUE:
                if (_playerKeys.keyBlue)
                {
                    DoorOpen();
                    _playerKeys.keyBlue = false;
                }
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
            CheckCanOpen(collision.GetComponent<PlayerKeysController>());
        }
    }
}
