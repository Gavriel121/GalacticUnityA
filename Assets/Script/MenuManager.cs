using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject[] buttons;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToController()
    {
        for(int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(false);
        }
        buttons[2].SetActive(true);

    }

    public void Back()
    {
        for (int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(true);
        }
        buttons[2].SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
