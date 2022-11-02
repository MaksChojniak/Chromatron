using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileManager : MonoBehaviour
{
    [SerializeField] public List<bool> currentTile;

    [SerializeField] private GridTile _gridTilePrefab;
    [SerializeField] private int _width, _height;
    [SerializeField] private Transform _cam;

    [SerializeField] private Color32 _color;

    void Awake()
    {
        
    }
    void Start()
    {
        GenerateGrid();   
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }

    void GenerateGrid()
    {
        float scale = 0.475f;

        for (int y = 0; y < _height; y++)
        {
            for(int x = 0; x < _width; x++)
            {
                var spawnedTile = Instantiate(_gridTilePrefab, new Vector3(x, y), Quaternion.identity, this.transform);
                spawnedTile.id = y * _height + x;

                SetTileColor(spawnedTile.GetComponent<GridTile>());
                spawnedTile.name = $"Tile  x -> {x}, y -> {y}" ;

                currentTile.Add(spawnedTile.currentTile);
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2, (float)_height / 2, -10);
        //_cam.transform.position = new Vector3(scale * 10, scale * 10, -10);
        _cam.transform.position = new Vector3(7.252f, 6.7575f, -10);

        this.transform.localScale = new Vector3(scale, scale, 1);
    }

    void SetTileColor(GridTile tile)
    {
        tile.currentColor = _color;
    }

}
