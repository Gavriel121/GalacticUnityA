using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(0, 0.1f, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
