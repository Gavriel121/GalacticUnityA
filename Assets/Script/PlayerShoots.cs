using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{
    public GameObject Laser;
    public int LaserLevel;

    public AudioSource audioSource;// אפקט סאונד
    public AudioClip LaserEffect; // סאונד יריה
    public AudioClip PickUpLaser; // סאונד אסיפת אייקון

    void Start()
    {
        LaserLevel = 1;
    }


    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }*/
    }

    public void Shoot()
    {
        if(LaserLevel == 1)
        {
            Instantiate(Laser, new Vector2(transform.position.x, transform.position.y + 1), Laser.transform.rotation);
        }
        else if(LaserLevel == 2)
        {
            Instantiate(Laser, new Vector2(transform.position.x + 0.25f, transform.position.y + 1), Laser.transform.rotation);
            Instantiate(Laser, new Vector2(transform.position.x - 0.25f, transform.position.y + 1), Laser.transform.rotation);
        }
        else if (LaserLevel > 2)
        {
            Instantiate(Laser, new Vector2(transform.position.x + 0.25f, transform.position.y + 1), Laser.transform.rotation);
            Instantiate(Laser, new Vector2(transform.position.x - 0.25f, transform.position.y + 1), Laser.transform.rotation);
            Instantiate(Laser, new Vector2(transform.position.x, transform.position.y + 1), Laser.transform.rotation);
        }

        audioSource.PlayOneShot(LaserEffect); //סאונד יריה 



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LaserIcon")
        {
            Destroy(collision.gameObject);
            LaserLevel++;
            audioSource.PlayOneShot(PickUpLaser); // סאונד אסיפה
        }
    }
}
