using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    EnemyManager enemyManager;

    public int EnemyHealth;
    public Transform[] Canons;
    public GameObject Shoot;
    public GameObject ImprovedShoot;
    public GameObject ExplosionEffect;
    public GameObject ImpactEffect;
    float DirX;
    float Speed = 0.5f;
    public Slider HelathBar;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        Invoke("NormalBlast", 2);
        Invoke("MidBlast", 10);
        Invoke("SuperBlast", 21);
        Invoke("ChangeDir", 5);
    }


    void Update()
    {
        EnemyMovement();
        HelathBar.value = EnemyHealth;
    }

    public void EnemyMovement() 
    {
        transform.position = new Vector2(transform.position.x + DirX * Speed, transform.position.y);
    }

    public void ChangeDir() // פונקציה שארחראית על שינוי התנועה 
    {
        DirX = Random.Range(-1, 1);
        Speed = Random.Range(0.01f, 0.001f); // משנה את המהירות 
        Invoke("ChangeDir", 8);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            EnemyHealth--;
            if (EnemyHealth == 0)
            {
                Destroy(gameObject);
                enemyManager.EnemyNum = 0;
                Instantiate(ExplosionEffect, new Vector2( transform.position.x, transform.position.y), ExplosionEffect.transform.rotation);
                Instantiate(ExplosionEffect, new Vector2(transform.position.x, transform.position.y - 2), ExplosionEffect.transform.rotation);
                Instantiate(ExplosionEffect, new Vector2(transform.position.x, transform.position.y + 2), ExplosionEffect.transform.rotation);
            }
            Instantiate(ImpactEffect, transform.position, ImpactEffect.transform.rotation);
        }

        if (collision.gameObject.tag == "Border") // אחראי לשנות כיוון לאיוב שהוא מתנגש בגבול 
        {
            if (DirX < 0)
            {
                DirX = 1;
            }
            else
            {
                DirX = -1;
            }
        }
    }

    public void NormalBlast()
    {
        Instantiate(Shoot, Canons[0].position, Shoot.transform.rotation);
        Instantiate(Shoot, Canons[1].position, Shoot.transform.rotation);
        Instantiate(Shoot, Canons[2].position, Shoot.transform.rotation);
        Instantiate(Shoot, Canons[3].position, Shoot.transform.rotation);
        Invoke("NormalBlast", 4);
    }

    public void MidBlast()
    {
        Instantiate(Shoot, Canons[0].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[0].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[1].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[1].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[2].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[2].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[3].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[3].position, Quaternion.Euler(0, 0, -35));
        Invoke("MidBlast", 10);
    }

    public void SuperBlast()
    {
        Instantiate(Shoot, Canons[0].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[0].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[1].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[1].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[2].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[2].position, Quaternion.Euler(0, 0, -35));
        Instantiate(Shoot, Canons[3].position, Quaternion.Euler(0, 0, 35));
        Instantiate(Shoot, Canons[3].position, Quaternion.Euler(0, 0, -35));
        Instantiate(ImprovedShoot, Canons[0].position, Shoot.transform.rotation);
        Instantiate(ImprovedShoot, Canons[1].position, Shoot.transform.rotation);
        Instantiate(ImprovedShoot, Canons[2].position, Shoot.transform.rotation);
        Instantiate(ImprovedShoot, Canons[3].position, Shoot.transform.rotation);
        Invoke("SuperBlast", 21);
    }
}
