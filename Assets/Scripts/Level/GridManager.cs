using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, transform);
                tile.name = $"Tile {x * 9 + y}";
                var isOffset = ((x + y) % 2 == 1);
                tile.tag = "Tile";
                tile.Init(isOffset, false);
            }
        }
        var portal = Instantiate(_tilePrefab, new Vector3(-1,4), Quaternion.identity, transform);
        portal.tag = "Create";
        portal.name = "Tile Create";
        portal.Init(false, true);
        portal = Instantiate(_tilePrefab, new Vector3(5, 0), Quaternion.identity, transform);
        portal.tag = "Portal";
        portal.name = "Tile Portal";
        portal.Init(false, true);
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
