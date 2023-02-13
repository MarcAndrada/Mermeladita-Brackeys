using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad y trayectoria
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.position += (Vector2)transform.right * velocity * Time.deltaTime;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("He chocado");
            //collision.GetComponent<testPlayerController>().die();
            testPlayerController player = collision.GetComponent<testPlayerController>();
            player.die();
            Destroy(gameObject);

        }

    }
}
