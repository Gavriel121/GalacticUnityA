using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    EasterEgg easterEgg;

    public GameObject[] EnemyType; // מערך פובליק בשביל שנוכל לגרור את סוג האוייבים שאנחנו רוצים באינספקטור בימקום לעשות המון מישתנים שונים 
    public int WavesNumber;
    public int EnemyNum;
    bool isWating;
    public Text WaveText;
    public GameObject wavetext;
    public GameObject WinText;

    void Start()
    {
        easterEgg = FindObjectOfType<EasterEgg>();
        WavesNumber = 0;
        EnemyNum = 0;
        isWating = false;
    }


    void Update()
    {
        if (WavesNumber == 0 && EnemyNum == 0 && isWating == false)// אחראי לקרוא לגל הראשון 
        {
            WaveText.text = "Wave-1";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveOne", 5);
        }
        else if (WavesNumber == 1 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-2";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveTow", 5);
        }
        else if (WavesNumber == 2 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-3";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveThree", 5);
        }
        else if (WavesNumber == 3 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-4";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveFour", 5);
        }
        else if (WavesNumber == 4 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-5";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveFive", 5);
        }
        else if (WavesNumber == 5 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-6";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveSix", 5);
        }
        else if (WavesNumber == 6 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-7";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveSeven", 5);
        }
        else if (WavesNumber == 7 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-8";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveEight", 5);
        }
        else if (WavesNumber == 8 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Wave-9";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveNine", 5);
        }
        else if (WavesNumber == 9 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WaveText.text = "Boss";
            wavetext.SetActive(true);
            isWating = true;
            Invoke("WaveTen", 5);
        }
        else if (WavesNumber == 10 && EnemyNum == 0 && isWating == false) //  אחראי לקרוא לגל השני 
        {
            WinText.SetActive(true);
            isWating = true;
            Invoke("BackToMenu", 5);
        }
    }

    public void WaveOne()
    {
        wavetext.SetActive(false);
        EnemyNum = 3;// אחראי על כצן האוייבים בגל 
        for(int i = 0; i < EnemyNum; i++)
        {
            float y = Random.Range(2, 4); // אחראי על מיקום אקראי על ציר הווי 
            float x = Random.Range(-5, 5); // אחראי על מיקום אקראי על ציר האיקס
            Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveTow()
    {
        wavetext.SetActive(false);
        EnemyNum = 7;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            if(i <= 5)// אחראי לייצר שלוש אוייבים רגילים 
            {
                float y = Random.Range(2, 3); // אחראי על מיקום אקראי על ציר הווי 
                float x = Random.Range(-5, 5); // אחראי על מיקום אקראי על ציר האיקס
                Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
            }
            else if(i > 5) // אחראי לייצר שני אוייבים מסוג 2 לאחר שלושת האוייבים הרגילים 
            {
                float y = 4; 
                float x = Random.Range(-5, 5); // אחראי על מיקום אקראי על ציר האיקס
                Instantiate(EnemyType[1], new Vector2(x, y), EnemyType[1].transform.rotation);
            }
            
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveThree()
    {
        wavetext.SetActive(false);
        EnemyNum = 8;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
             float y = Random.Range(2, 4);  
             float x = Random.Range(-5, 5); 
             Instantiate(EnemyType[1], new Vector2(x, y), EnemyType[1].transform.rotation);

        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveFour()
    {
        wavetext.SetActive(false);
        EnemyNum = 6;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            float y = Random.Range(2, 4);
            float x = Random.Range(-5, 5);
            Instantiate(EnemyType[2], new Vector2(x, y), EnemyType[2].transform.rotation);

        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveFive()
    {
        wavetext.SetActive(false);
        EnemyNum = 15;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            if(i < 10)
            {
                float y = Random.Range(2, 3);
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
            }
            else if(i >= 10)
            {
                float y = 4;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[2], new Vector2(x, y), EnemyType[2].transform.rotation);
            }          
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveSix()
    {
        wavetext.SetActive(false);
        EnemyNum = 25;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            float y = Random.Range(2, 4); // אחראי על מיקום אקראי על ציר הווי 
            float x = Random.Range(-5, 5); // אחראי על מיקום אקראי על ציר האיקס
            Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveSeven()
    {
        wavetext.SetActive(false);
        EnemyNum = 15;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            if (i < 10)
            {
                float y = Random.Range(2, 3);
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
            }
            else if (i >= 10)
            {
                float y = 4;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[1], new Vector2(x, y), EnemyType[1].transform.rotation);
            }
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
        
    }

    public void WaveEight()
    {
        wavetext.SetActive(false);
        EnemyNum = 18;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            if (i < 10)
            {
                float y = 2;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
            }
            else if (i >= 10 && i < 14)
            {
                float y = 3;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[1], new Vector2(x, y), EnemyType[1].transform.rotation);
            }
            else if (i >= 14)
            {
                float y = 4;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[2], new Vector2(x, y), EnemyType[2].transform.rotation);
            }
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveNine()
    {
        wavetext.SetActive(false);
        EnemyNum = 20;// אחראי על כצן האוייבים בגל 
        for (int i = 0; i < EnemyNum; i++)
        {
            if (i < 10)
            {
                float y = 2;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[0], new Vector2(x, y), EnemyType[0].transform.rotation);
            }
            else if (i >= 10 && i < 18)
            {
                float y = 3;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[1], new Vector2(x, y), EnemyType[1].transform.rotation);
            }
            else if (i >= 18)
            {
                float y = 4;
                float x = Random.Range(-5, 5);
                Instantiate(EnemyType[2], new Vector2(x, y), EnemyType[2].transform.rotation);
            }
        }
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void WaveTen()
    {
        EnemyNum = 1;
        wavetext.SetActive(false);
        Instantiate(EnemyType[3], new Vector2(0, 2.88f), EnemyType[3].transform.rotation);
        WavesNumber++; // מעלה את מספר הגלים בשביל שמספר האוייבים יגיע לאפס הוא יקרא לגל הבא 
        isWating = false;
    }

    public void BackToMenu()
    {
        easterEgg.ActiveEasterEgg();
        SceneManager.LoadScene(0);
    }
}
