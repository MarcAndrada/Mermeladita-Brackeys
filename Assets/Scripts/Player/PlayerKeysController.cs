using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeysController : MonoBehaviour
{
    public bool keyGreen;
    public bool keyRed;
    public bool keyBlue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Key"))
        {
            switch (collision.GetComponent<KeyController>().type)
            {
                case DoorsBehaivour.ColorType.GREEN:
                    keyGreen= true;
                    break;
                case DoorsBehaivour.ColorType.RED:
                    keyRed= true;   
                    break;
                case DoorsBehaivour.ColorType.BLUE:
                    keyBlue= true;  
                    break;
                default:
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }
}
