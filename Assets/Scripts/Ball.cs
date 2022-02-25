using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private static float z;

    private static Color currentColor;

    private MeshRenderer meshRenderer;

    private float height = 0.58f, speed = 6;

    private bool move;


    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        move = false;    
    }

    void Update()
    {
        if(Touch.IsPressing())
            move = true;
        
        if (move)
            Ball.z += speed * 0.025f;

        transform.position = new Vector3(0, height, Ball.z);

        UpdateColor();
    }


    void UpdateColor()
    {
        meshRenderer.sharedMaterial.color = currentColor;
    }

    public static float GetZ()
    {
        return Ball.z;
    }

    public static Color SetColor(Color color)
    {
        return currentColor = color;
    }

    public static Color GetColor()
    {
        return currentColor;
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Hit")
        {
            print("We Hit The wall");
        }

        if (target.tag == "Fail")
        {
            print("Game Over");
        }

        if(target.tag == "FinishLine")
        {
            print("LevelUp");
        }

    }
}
