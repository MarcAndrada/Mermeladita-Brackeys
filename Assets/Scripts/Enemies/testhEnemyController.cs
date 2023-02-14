using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testhEnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Te tiro un shuriken");
        }
    }
}
