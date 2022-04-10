using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public int Life;
    public GameObject[] HeartsImages; // מערך שמטרתו להחזיק את התמונות של הלבבות
    public GameObject ShieldImage;
    public GameObject GameOverText;
    public Text ScoreText;
    bool oneTime;

    void Start()
    {
        Life = 3; // כמות הלבבות    
        Score = 0;
        ShieldImage.SetActive(false);
        oneTime = true;
    }


    void Update()
    {
        ScoreText.text = "Score:" + " " + Score.ToString();
        if(Life == 0 && oneTime)
        {
            oneTime = false;
            GameOverText.SetActive(true);
            Invoke("GameOver", 3);
        }
    }


    public void DecreaseLife()// i call this function from the script PlayerLifeEngine
    {
        Life--;
        int i = 0;
        while(i < Life) // עובר לפי מספר הפעמים שיש בעצם את משתנה לייף את המערך ודואג שלפי כמות החיים התמונות עובדות 
        {
            HeartsImages[i].SetActive(true);
            i++;
        }
        HeartsImages[i].SetActive(false); // בעצם מבטל את התמונה האחרונה שמערך 
       
    }

    public void IncreaseLife()
    {
        if (Life < 3)
        {
            Life++;
            int i = 0;
            while (i < Life)
            {
                HeartsImages[i].SetActive(true);
                i++;
            }

        }
    }

    public void DecreaseScore()
    {
        if(Score > 500)
        {
            Score = Score - 500;
        }
        else
        {
            Score = 0;
        }
    }

    public void IncreaseScore()
    {
        Score = Score + 50; 
    }

    public void ActiveShieldImage()
    {
        ShieldImage.SetActive(true);
    }

    public void DactivateShieldImage()
    {
        ShieldImage.SetActive(false);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
