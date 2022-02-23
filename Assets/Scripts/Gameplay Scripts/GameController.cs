using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Color[] colors;
    [HideInInspector]
    public Color hitColor, failColor;

    void Awake()
    {
        GenerateColors();
    }

    void Update()
    {
        
    }

    void GenerateColors()
    {
        hitColor = colors[Random.Range(0, colors.Length)];

        failColor = colors[Random.Range(0, colors.Length)];
        while(failColor == hitColor)
            failColor = colors[Random.Range(0, colors.Length)];

        Ball.SetColor(hitColor);
    }
}
