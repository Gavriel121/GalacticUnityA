using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeEngine : MonoBehaviour
{
    GameManager gameManager;
    public GameObject EnegryField;
    public GameObject ImpactEffect;
    public AudioSource audioSource;    
    public AudioClip PickUpRepair;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();// מקבל את האפשרות לגשת לסקריפט של הגיים מנג'ר
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shoot" || collision.gameObject.tag == "Enemy")// בןדק התנגשות עם ירייה של אויב אם המגן לא מופעל 
        {
            if(EnegryField.activeSelf == false)
            {
                gameManager.DecreaseLife();
                gameManager.DecreaseScore();
                Instantiate(ImpactEffect, transform.position, ImpactEffect.transform.rotation);
            }
            
        }
        if(collision.gameObject.tag == "RepairIcon")
        {
            gameManager.IncreaseLife();
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(PickUpRepair);
            gameManager.IncreaseScore();
        }
    }
}
