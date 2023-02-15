using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private shurikenThrowController shurikenController;

    private EnemyBehaviour enemyBehaviour;
    private void Awake()
    {
        shurikenController = GetComponent<shurikenThrowController>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
    public void EnemyDie()
    {
        //Empezar animación de muerte 

        //Desactivamos los scripts del comportamiento del enemigo
        shurikenController.enabled = false;
        enemyBehaviour.enabled = false;
    }

    public void EnemyRespawn()
    {
        //Poner la animación base

        //Activar los scripts del comportamiento del enemigo
        shurikenController.enabled = true;
        enemyBehaviour.enabled = true;
    }
}
