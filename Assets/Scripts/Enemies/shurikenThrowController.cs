using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenThrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject shuriken;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float timeToThrow;
    
    private float timeWaited = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeWaited += Time.deltaTime;
        if (timeWaited >= timeToThrow)
        {
            ThrowShuriken();
        }
    }

    void ThrowShuriken()
    {
        Vector3 posToSpawn = EnemiesManager._instance._player.transform.position - transform.position;
        posToSpawn = posToSpawn.normalized * offset + transform.position;
        Instantiate(shuriken, posToSpawn,Quaternion.identity);
        timeWaited = 0;
    }
}
