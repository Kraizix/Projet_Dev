using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadLevel : MonoBehaviour
{

    [SerializeField] private Player player;
    private string level = "RRRRRRRRRRULLLLLLLLUUUUU";
    private float bpm;
    private string levelName;
    [SerializeField] private Tile _tilePrefab;
    private int X = 0;
    private int Y = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetString("level");
            bpm = PlayerPrefs.GetFloat("bpm");
            levelName = PlayerPrefs.GetString("levelName");
            player.BPM = bpm;

        }
        else
        {
            SceneManager.LoadScene("CreateLevel");
            return;
        }
        switch(level[1])
        {
            case 'U':
                player._blue.transform.position = new Vector3(0,-1);
                break;
            case 'D':
                player._blue.transform.position = new Vector3(0,1);
                break;
            case 'L':
                player._blue.transform.position = new Vector3(1,0);
                break;
            case 'R':
                player._blue.transform.position = new Vector3(-1,0);
                break;
        }
        GenerateGrid();
    }

    void GenerateGrid()
    {
        var tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
        tile.name = $"Tile 0";
        var isOffset = false;
        var isPortal = false;
        tile.tag = "Tile";
        tile.Init(isOffset, isPortal);
        for(int i = 1; i < level.Length;i++){
            switch(level[i]){
                case 'L':
                    X--;
                    break;
                case 'R':
                    X++;
                    break;
                case 'U':
                    Y++;
                    break;
                case 'D':
                    Y--;
                    break;
            }
            tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
            tile.name = $"Tile {i}";
            isOffset = i%2 == 1;
            isPortal = false;
            tile.tag = "Tile";
            if(i == level.Length - 1){
                isPortal = true;
                tile.tag="Portal";
            }
            tile.Init(isOffset, isPortal);
        }
    }

}
