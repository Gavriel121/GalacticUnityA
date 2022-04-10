using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFieldControler : MonoBehaviour
{
    GameManager gameManager;
    public GameObject EnergyField;
    bool isShield;

    public AudioSource audioSource;
    public AudioClip PickUpShield;
    public AudioClip Active; // סאונד הפעלת מגן


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        isShield = false;
    }

    // Update is called once per frame
    void Update()
    {
     /*   if(Input.GetKeyDown(KeyCode.F) && isShield)
        {
            
            Shield();
        }*/
        
    }

    public void Shield()
    {
        if (isShield) 
        { 
        isShield = false;
        EnergyField.SetActive(true);
        Invoke("DisableEnergyField", 5); // דואג לכבות את המגן אחראי 5 שניות 
        audioSource.PlayOneShot(Active);
        gameManager.DactivateShieldImage();
        }
    }

    public void DisableEnergyField() // הפונקציה שמכבה את המגן 
    {
        EnergyField.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ShieldIcon")// אחראי להפוך את הבוליאן לאמת ברגע שהשחקן אוסף את המגן
        {
            isShield = true;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(PickUpShield);
            gameManager.ActiveShieldImage();
        }

        
    }
}
