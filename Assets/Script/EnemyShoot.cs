using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    

    void Start()
    {
        
    }


    void Update()
    {
        if(gameObject.name == "EnemyShoot(Clone)")
        {
            transform.Translate(0, -0.01f, 0);
        }
        else if(gameObject.name == "ImprovedEnemyShoot(Clone)")
        {
            transform.Translate(0, -0.02f, 0);
        }

        



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnergyField" || collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
