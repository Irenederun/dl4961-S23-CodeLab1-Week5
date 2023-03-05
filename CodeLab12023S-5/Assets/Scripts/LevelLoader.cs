using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    public GameObject player;
    public GameObject block;
    public GameObject door;
    public GameObject trap;
    public GameObject level;
    public GameObject paddle;
    public float xOffSet;
    public float yOffSet;

    private int currentLevel = 0;
    private GameObject currentPlayer;
    private GameObject currentPaddle;
    private Vector3 playerStartPos;
    private Vector3 paddleStartPos;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            Destroy(level);
            LoadLevel();
        }
    }

    private const string FILE_NAME = "LevelNum.txt";
    private const string FILE_DIR = "/Levels/";
    private string FILE_PATH;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        LoadLevel();
    }
    
    public void LoadLevel()
    {
        level = new GameObject("Level");
        
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");

        string[] fileLines = File.ReadAllLines(newPath);

        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            string lineText = fileLines[yPos];//read the current line and convert into string
            char[] lineChars = lineText.ToCharArray();//convert this line into array of chars

            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                char thisChar = lineChars[xPos];
                GameObject newObj = null;

                switch (thisChar)
                {
                    case 'B':
                        newObj = Instantiate<GameObject>(block);
                        break;
                    case 'D':
                        newObj = Instantiate<GameObject>(door);
                        break;
                    case 'T':
                        newObj = Instantiate<GameObject>(trap);
                        break;
                    case 'P':
                        playerStartPos = new Vector3(1.23f, 0f);
                        newObj = Instantiate<GameObject>(player);
                        currentPlayer = newObj;
                        break;
                    case 'A':
                        //paddleStartPos = new Vector3(0, -5f);
                        newObj = Instantiate<GameObject>(paddle);
                        currentPaddle = newObj;
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.position = new Vector2((xPos - xOffSet)*1.8f, yOffSet - yPos);
                    newObj.transform.parent = level.transform;
                }
            }
        }
    }
}
