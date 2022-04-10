using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public Joystick joystick;

    float X;
    float Y;
    float Speed;

    public GameObject EngineFlame;

   

    void Start()
    {
        Speed = 0.04f;
        EngineFlame.transform.localScale = new Vector3(0.03f, 0.03f, 1);
    }


    void Update()
    {
        /*X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");*/
        X = joystick.Horizontal;
        Y = joystick.Vertical;
        transform.position = new Vector2(transform.position.x + X * Speed, transform.position.y + Y * Speed);
        FlameSize();



    }

    public void FlameSize()
    {
        if(Y > 0)
        {
            EngineFlame.transform.localScale = new Vector3(0.04f, 0.04f, 1);
        }
        else if(Y < 0)
        {
            EngineFlame.transform.localScale = new Vector3(0.02f, 0.02f, 1);
        }
        else if(Y == 0)
        {
            EngineFlame.transform.localScale = new Vector3(0.03f, 0.03f, 1);
        }
    }
}
