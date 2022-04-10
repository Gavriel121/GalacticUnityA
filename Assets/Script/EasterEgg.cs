using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public GameObject EasterEggLaser;
    int isEasterEgg;

    void Start()
    {
        if (PlayerPrefs.HasKey("EasterEgg"))
        {
            isEasterEgg = PlayerPrefs.GetInt("EasterEgg");
        }
        else
        {
            PlayerPrefs.SetInt("EasterEgg", isEasterEgg = 0);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isEasterEgg == 1)
        {
            Instantiate(EasterEggLaser, new Vector2(transform.position.x, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x + 0.25f, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x - 0.25f, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x + 0.25f, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x - 0.25f, transform.position.y + 1), EasterEggLaser.transform.rotation);
            Instantiate(EasterEggLaser, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.Euler(0, 0,-5));
            Instantiate(EasterEggLaser, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.Euler(0, 0, 5));
        }

    }

    public void ActiveEasterEgg()
    {
        PlayerPrefs.SetInt("EasterEgg", isEasterEgg = 1);
    }
}
