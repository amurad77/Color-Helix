using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject finishLine;
    private GameObject[] walls2;

    public Color[] colors;
    [HideInInspector]
    public Color hitColor, failColor;

    private int wallsSpawnNumber = 11;
    private float z = 7;

    private bool colorBump;

    void Awake()
    {
        instance = this;
        GenerateColors();
        PlayerPrefs.GetInt("Level", 1);

    }

    void Start()
    {
        
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        
        if (PlayerPrefs.GetInt("Level") >= 1 && PlayerPrefs.GetInt("Level") <= 4)
            wallsSpawnNumber = 12;
        else if (PlayerPrefs.GetInt("Level") >= 5 && PlayerPrefs.GetInt("Level") <= 10)
            wallsSpawnNumber = 13;
        else
            wallsSpawnNumber = 14;

        z = 7;

        DeleteWalls();
        colorBump = false;
        SpawnWalls();
    }

    void GenerateColors()
    {
        hitColor = colors[Random.Range(0, colors.Length)];

        failColor = colors[Random.Range(0, colors.Length)];
        while(failColor == hitColor)
            failColor = colors[Random.Range(0, colors.Length)];

        Ball.SetColor(hitColor);
    }

    void DeleteWalls()
    {
        walls2 = GameObject.FindGameObjectsWithTag("Fail");

        if(walls2.Length > 1)
        {
            for (int i = 0; i < walls2.Length; i++)
            {
                Destroy(walls2[i].transform.parent.gameObject);
            }
        }

        Destroy(GameObject.FindGameObjectWithTag("ColorBump"));
    }

    void SpawnWalls()
    {
        for (int i = 0; i < wallsSpawnNumber; i++)
        {
            GameObject wall;

            if (Random.value <= 0.2 && !colorBump && PlayerPrefs.GetInt("Level") >= 3);
            {
                colorBump = true;
                wall = Instantiate(Resources.Load("ColorBump") as GameObject, transform.position, Quaternion.identity);
            }
            if (Random.value <= 0.2 && PlayerPrefs.GetInt("Level") >= 6)
            {
                wall = Instantiate(Resources.Load("Walls") as GameObject, transform.position, Quaternion.identity);

            }
            if (i >= wallsSpawnNumber - 1 && !colorBump && PlayerPrefs.GetInt("Level") >= 3)
            {
                colorBump = true;
                wall = Instantiate(Resources.Load("ColorBump") as GameObject, transform.position, Quaternion.identity);
            }
            else
            {
                wall = Instantiate(Resources.Load("Wall") as GameObject, transform.position, Quaternion.identity);
            }
            

            wall.transform.SetParent(GameObject.Find("Helix").transform);
            wall.transform.localPosition = new Vector3(0, 0, z);
            float randomRotation = Random.Range(0, 360);
            wall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, randomRotation));
            z += 7;

            if(i <= wallsSpawnNumber)
                finishLine.transform.position = new Vector3(0, 0.03f, z);
        }
    }


}
