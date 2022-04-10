using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    EnemyManager enemyManager;
    GameManager gameManager;

    public int EnemyHealth;
    public GameObject Shoot;
    public GameObject LaserIcon;
    public GameObject ShieldIcon;
    public GameObject RepairIcon;
    int RandomTimeToShoot;
    public GameObject ExplosionEffect;
    public GameObject ImpactEffect;
    
        



    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();// מבקש גישה לסקריפט של האינמי מנג'ר
        gameManager = FindObjectOfType<GameManager>();
        RandomTimeToShoot = Random.Range(3, 9);
        Invoke("EnemyShoot", RandomTimeToShoot); // קורא לפונקציית היקי בפעם הראשונה 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            EnemyHealth--;
            if(EnemyHealth == 0)
            {
                Destroy(gameObject);
                

            }
            Instantiate(ImpactEffect, transform.position, ImpactEffect.transform.rotation);
        }
    }

    public void EnemyShoot()
    {    
        Instantiate(Shoot, new Vector2(transform.position.x, transform.position.y - 0.25f), Shoot.transform.rotation);
        RandomTimeToShoot = Random.Range(5, 10);
        Invoke("EnemyShoot", RandomTimeToShoot); // אחראי לקרוא לפונקציית הירי עוד פעם כל כמה שניות בצורה רנדומלית ככה נוצר מצב שהאויב לא מפסיק לירות 

        
    }

    void OnDestroy()// פונקציה שמתבצעת רק כאשר האובייקט נהרס
    {
        enemyManager.EnemyNum--; // מוריד את מספר האוייבים שסצנה על מנת שכאשר הוא יגיע לאפס האנמי מנג'ר יקרא לגל הבא 
        int ChanceToLaser = Random.RandomRange(1, 15);// אחראי על הסיכוי באמת שהשחקן יקבל יריות כרגע הסיכוי לקבל גבוה כי אני רוצה רק לבדוק שהכל עובד
        int ChanceToShield = Random.RandomRange(1, 20);  // אחראי על הסיכוי באמת שהשחקן יקבל מגן כרגע הסיכוי לקבל גבוה כי אני רוצה רק לבדוק שהכל עובד
        int ChanceToRepair = Random.RandomRange(1, 25);
        if (ChanceToLaser == 2) // יוצר מצב שרק אחד לכמה איוביים באמת השחקן יקבל שיפור ליריות 
        {
            Instantiate(LaserIcon, transform.position, LaserIcon.transform.rotation);
        }
        if(ChanceToShield == 2)
        {
            Instantiate(ShieldIcon, transform.position, LaserIcon.transform.rotation);
        }
        if(ChanceToRepair == 2)
        {
            Instantiate(RepairIcon, transform.position, RepairIcon.transform.rotation);
        }

        Instantiate(ExplosionEffect, transform.position, ExplosionEffect.transform.rotation);
        gameManager.IncreaseScore();
    }
}
