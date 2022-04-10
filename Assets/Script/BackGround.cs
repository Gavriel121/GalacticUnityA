using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float ScroolSpeed = 1f;
    private float offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }


    void Update()
    {
        offset += (Time.deltaTime * ScroolSpeed) / 10;
        material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
