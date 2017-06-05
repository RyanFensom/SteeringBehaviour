using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {
    public Renderer rend;
    public Color[] foxColors;

    void Start()
    {/*
        Color randomColor = new Color();
        randomColor.r = Random.Range(0f, 1f);
        randomColor.g = Random.Range(0f, 1f);
        randomColor.b = Random.Range(0f, 1f);
        rend.material.color = randomColor;
        */
        int index = Random.Range(0, foxColors.Length);
        rend.material.color = foxColors[index];
    }
}
