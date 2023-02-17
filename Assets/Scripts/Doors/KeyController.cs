using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorsBehaivour;

public class KeyController : MonoBehaviour
{
    public DoorsBehaivour.ColorType type;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
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
}
