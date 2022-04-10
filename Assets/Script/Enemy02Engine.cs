using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy02Engine : MonoBehaviour
{
    EnemyManager enemyManager;
    GameManager gameManager;

    public int EnemyHealth;
    public GameObject Shoot;
    public GameObject LaserIcon;
    public GameObject ShieldIcon;
    public GameObject RepairIcon;
    float DirX;
    float Speed = 0.01f;
    int RandomTimeToShoot;
    public GameObject ExplosionEffect;
    public GameObject ImpactEffect;



    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>(); // מבקש גישה לסקריפט של האינמי מנג'ר
        gameManager = FindObjectOfType<GameManager>();
        RandomTimeToShoot = Random.Range(5, 10);
        Invoke("EnemyShoot", RandomTimeToShoot); // קורא לפונקציית הירי בפעם הראשונה 
        DirX = 1;
        Invoke("ChangeDir", 5);// קורא לפונקציה לשינוי התנועה 
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            EnemyHealth--;
            if (EnemyHealth == 0)
            {
                Destroy(gameObject);
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

    public void EnemyMovement() // פונקציה שמזיזה את האויב נמצאת באפדייט
    {
        transform.position = new Vector2(transform.position.x + DirX * Speed, transform.position.y);
    }

    public void ChangeDir() // פונקציה שארחראית על שינוי התנועה 
    {
        DirX = Random.Range(-1, 1);
        Speed = Random.Range(0.01f, 0.001f); // משנה את המהירות 
        Invoke("ChangeDir", 5);
    }

    public void EnemyShoot()
    {    
         Instantiate(Shoot, new Vector2(transform.position.x, transform.position.y - 0.25f), Quaternion.Euler(0, 0, 35));
         Instantiate(Shoot, new Vector2(transform.position.x, transform.position.y - 0.25f), Quaternion.Euler(0, 0, -35));// שני שורות הקוד האלה יוצרות שני יריות באלכסון 
         RandomTimeToShoot = Random.Range(5, 10);
         Invoke("EnemyShoot", RandomTimeToShoot);

        
    }

    void OnDestroy()// פונקציה שמתבצעת רק כאשר האובייקט נהרס
    {
        enemyManager.EnemyNum--; // מוריד את מספר האוייבים שסצנה על מנת שכאשר הוא יגיע לאפס האנמי מנג'ר יקרא לגל הבא 
        int ChanceToLaser = Random.RandomRange(1, 14);// אחראי על הסיכוי באמת שהשחקן יקבל יריות כרגע הסיכוי לקבל גבוה כי אני רוצה רק לבדוק שהכל עובד
        int ChanceToShield = Random.RandomRange(1, 19);  // אחראי על הסיכוי באמת שהשחקן יקבל מגן כרגע הסיכוי לקבל גבוה כי אני רוצה רק לבדוק שהכל עובד
        int ChanceToRepair = Random.RandomRange(1, 24);
        if (ChanceToLaser == 2) // יוצר מצב שרק אחד לכמה איוביים באמת השחקן יקבל שיפור ליריות 
        {
            Instantiate(LaserIcon, transform.position, LaserIcon.transform.rotation);
        }
        if (ChanceToShield == 2)
        {
            Instantiate(ShieldIcon, transform.position, LaserIcon.transform.rotation);
        }
        if (ChanceToRepair == 2)
        {
            Instantiate(RepairIcon, transform.position, RepairIcon.transform.rotation);
        }

        Instantiate(ExplosionEffect, transform.position, ExplosionEffect.transform.rotation);

        gameManager.IncreaseScore();
        gameManager.IncreaseScore();
    }
}
