using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileManagerUI : MonoBehaviour
{
    [SerializeField] public List<bool> currentTile;

    [SerializeField] private GridTileUI _gridTilePrefab;
    [SerializeField] private int _width, _height;

    [SerializeField] private Color32 _color;

    void Start()
    {
        GenerateGrid();    
    }
    void GenerateGrid()
    {

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                var spawnedTile = Instantiate(_gridTilePrefab, new Vector3(x, y), Quaternion.identity, this.transform);
                spawnedTile.id = y * _height + x;

                SetTileColor(spawnedTile.GetComponent<GridTileUI>());// (y * _height + x) % 2 == 0);
                spawnedTile.name = $"Tile  x -> {x}, y -> {y}";

                currentTile.Add(spawnedTile.currentTile);
            }
        }
    }

    void SetTileColor(GridTileUI tile)
    {
        tile.currentColor = _color;
    }
}
