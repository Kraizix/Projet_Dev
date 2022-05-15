using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_mng : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void GenerateGrid()
    {   
        
        for (int x = 0; x < 20; x++){
            int y= 0;
            var tile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, transform);
            tile.name = $"Tile {x}";
            var isOffset = ((x + y) % 2 == 1);
            var isPortal = false;
            tile.tag = "Tile";
            tile.Init(isOffset, isPortal);
            Debug.Log(tile.transform.position);
        }
        for (int x = 19; x < 40; x++){
            int y= 1;
            var tile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, transform);
            tile.name = $"Tile {x+1}";
            var isOffset = ((x + y) % 2 == 1);
            var isPortal = false;
            if(x == 39){
                    isPortal = true;
                    tile.tag = "Portal";
                } else {
                    tile.tag = "Tile";
                }
            tile.Init(isOffset, isPortal);
            Debug.Log(tile.transform.position);
        }
    
    }
}
