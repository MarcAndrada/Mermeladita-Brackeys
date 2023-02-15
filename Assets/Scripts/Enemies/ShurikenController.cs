using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    private Rigidbody2D rb2d;

    Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad y trayectoria
        direction = (EnemiesManager._instance._player.transform.position - transform.position).normalized;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
   
    //Movimiento del shuriken, Vector * alfa * deltatime (Para que los shuriken vayan a la misma velocidad en todos los pc)
    void Update()
    {
        rb2d.position += direction * velocity * Time.deltaTime;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el shuriken choca contra el player, se rompe y el player muere
        if (collision.CompareTag("Player")){
            //collision.GetComponent<testPlayerController>().die();
            testPlayerController player = collision.GetComponent<testPlayerController>();
            player.die();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
