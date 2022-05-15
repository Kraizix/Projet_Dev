using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{

    
    [SerializeField] private string level = " ";
    private int X = 0;
    private int Y = 0;
    private bool keyPressed = false;
    private string key = "";
    [SerializeField] private string levelName;
    [SerializeField] private float bpm = 0f;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    [SerializeField] private InputField _bpmInput;
    [SerializeField] private InputField _levelInput;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetString("level");
            bpm = PlayerPrefs.GetFloat("bpm");
            levelName = PlayerPrefs.GetString("levelName");
            _bpmInput.text = bpm.ToString();
            _levelInput.text = levelName;
            LoadTiles();
        }else {
            var tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
            tile.name = $"Tile 0";
            tile.tag = "Tile";
            tile.Init(false,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _cam.transform.position = new Vector3(X,Y,-10);
        if(_bpmInput.isFocused ||_levelInput.isFocused){
            return;
        }
        string lastKey = level.Substring(level.Length-1);
        if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            X--;
            if(X == 0 && Y == 0 && level.Length != 1){
                X++;
                return;
            }
            if(lastKey == "R")
            {
                Debug.Log("Destroy L");
                Destroy(_tiles[_tiles.Count - 1].gameObject);
                _tiles.RemoveAt(_tiles.Count -1);
                level = level.Substring(0, level.Length-1);
                return;
            }
            
            key="L";
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            X++;
            if (X == 0 && Y == 0 && level.Length != 1)
            {
                X--;
                return;
            }
            if(lastKey == "L")
            {
                Debug.Log("Destroy R");
                Destroy(_tiles[_tiles.Count - 1].gameObject);
                _tiles.RemoveAt(_tiles.Count -1);
                level = level.Substring(0, level.Length-1);
                return;
            }
            
            key="R";
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Y++;
            if (X == 0 && Y == 0 && level.Length != 1)
            {
                Y--;
                return;
            }
            if(lastKey == "D")
            {
                Debug.Log("Destroy U");
                Destroy(_tiles[_tiles.Count - 1].gameObject);
                _tiles.RemoveAt(_tiles.Count -1);
                level = level.Substring(0, level.Length-1);
                return;
            }
            
            key="U";
            keyPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Y--;
            if (X == 0 && Y == 0 && level.Length != 1)
            {
                Y++;
                return;
            }
            if(lastKey == "U")
            {
                Debug.Log("Destroy D");
                Destroy(_tiles[_tiles.Count - 1].gameObject);
                _tiles.RemoveAt(_tiles.Count -1);
                level = level.Substring(0, level.Length-1);
                return;
            }
            
            key="D";
            keyPressed = true;
        }
        if(keyPressed)
        {
            if(checkPos()){
                keyPressed = false;
                Debug.Log("Conflict");
                if (key == "L")
                {
                    X++;
                } else if (key == "R")
                {
                    X--;
                } else if (key == "U")
                {
                    Y--;
                } else if (key == "D")
                {
                    Y++;
                }
                return;
            }
            var tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
            tile.name = $"Tile {level.Length}";
            var isOffset = level.Length%2 == 1;
            var isPortal = false;
            tile.tag = "Tile";
            tile.Init(isOffset, isPortal);
            level += key;
            keyPressed = false;
            _tiles.Add(tile);
        }
    }

    public bool checkPos()
    {
        return _tiles.Any(_t => _t.gameObject.transform.position == new Vector3(X,Y));
    }

    public void SaveGame()
    {
         if(level.Length <= 2|| levelName == "")
        {
            Debug.Log("Not enough tiles or no levelName");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/" + levelName + ".dat");
        Level lvl = new Level();
        lvl.level = level;
        lvl.name = levelName;
        lvl.bpm = bpm;
        bf.Serialize(file,lvl);
        file.Close();
        Debug.Log("Saved");
    }



    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(levelName);
        Debug.Log(bpm);
        FileStream file = File.Open(Application.persistentDataPath + "/"+ levelName +".dat", FileMode.Open);
        Debug.Log("ici");
        Level lvl = (Level)bf.Deserialize(file);
        Debug.Log("la");
        file.Close();
        level = lvl.level;
        bpm = lvl.bpm;
        levelName = lvl.name;
        _bpmInput.text = bpm.ToString();
        _levelInput.text = levelName;
        foreach(Tile _t in _tiles){
            Destroy(_t.gameObject);
        }
        _tiles = new List<Tile>();
        X = 0;
        Y = 0;
        LoadTiles();
    }

    public void Reset()
    {
        foreach(Tile _t in _tiles){
            Destroy(_t.gameObject);
        }
        _tiles = new List<Tile>();
        X = 0;
        Y = 0;
        level = " ";
        bpm = 120;
        levelName = "";
        _bpmInput.text = "";
        _levelInput.text = "";
        var tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
        tile.name = $"Tile 0";
        tile.tag = "Tile";
        tile.Init(false,false);
    }

    public void LoadTiles()
    {
        for(int i = 0;i < level.Length;i++)
        {
            char c = level[i];
            if(c == 'L')
            {
                X--;
            } else if (c == 'R')
            {
                X++;
            } else if (c == 'U')
            {
                Y++;
            } else if (c == 'D')
            {
                Y--;
            }
            var tile = Instantiate(_tilePrefab, new Vector3(X,Y), Quaternion.identity, transform);
            tile.name = $"Tile {i}";
            var isOffset = i%2 == 1;
            var isPortal = false;
            tile.tag = "Tile";
            tile.Init(isOffset, isPortal);
            _tiles.Add(tile);
        }
    }
    public void StartLevel()
    {
        if(level.Length <= 2|| levelName == "")
        {
            return;
        }
        PlayerPrefs.SetFloat("bpm", bpm == 0 ? 80 : bpm);
        PlayerPrefs.SetString("level", level);
        PlayerPrefs.SetString("levelName", levelName);
        SceneManager.LoadScene("LoadLevel");
    }
    public void SetLevelName(string _levelName){
        Debug.Log(_levelName);
        levelName = _levelName;
    }
    public void SetBPM(string _bpm)
    {
        try {
            bpm = float.Parse(_bpm);
        } catch
        {
            if(_bpm == ""){
                bpm = 0;
            }
            _bpmInput.text = bpm.ToString();
        }
    }
}
