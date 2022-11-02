using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gritTileWithItem;

    [SerializeField] private List<GameObject> _allGridTiles = new List<GameObject>();

    [SerializeField] private GameObject _currentGridTile;

    [SerializeField] public GameObject _cursorItem;


    [Space(9)]
    [Header("Items Prefabs")]
    [SerializeField] private GameObject _imagePrefabUI;
    [SerializeField] private GameObject _imagePrefab;

    [SerializeField] private bool _check;
    private void Update()
    {
        GetAllGridTiles();
        CheckAllGridTiles();

    }

    private void GetAllGridTiles()
    {
        _allGridTiles.Clear();
        var objects = GameObject.FindGameObjectsWithTag("GridStorages");

        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < objects[i].transform.childCount; j++)
            {
                _allGridTiles.Add(objects[i].transform.GetChild(j).gameObject);
            }
        }
    }

    private void CheckAllGridTiles()
    {
        _gritTileWithItem.Clear();
        for (int i = 0; i < _allGridTiles.Count; i++)
        {
            if (i < _allGridTiles.Count - 441)
            {
                CheckGridUI(i);
            }
            else
            {
                CheckGrid(i);
            }
        }
    }

    private void CheckGrid(int i)
    {
        if (_allGridTiles[i].GetComponent<GridTile>().currentTile)
        {
            _currentGridTile = _allGridTiles[i];
        }

        if (_allGridTiles[i].GetComponent<GridTile>().eqipmentItems.Count > 0)
        {
            _gritTileWithItem.Add(_allGridTiles[i]);
        }
    }

    private void CheckGridUI(int i)
    {
        if (_allGridTiles[i].GetComponent<GridTileUI>().currentTile)
        {
            _currentGridTile = _allGridTiles[i];
        }

        if (_allGridTiles[i].GetComponent<GridTileUI>().eqipmentItems.Count > 0)
        {
            _gritTileWithItem.Add(_allGridTiles[i]);
        }
    }


    public void DisplayCursorItem(Sprite image)
    {
        var cursorImage = _cursorItem.GetComponent<Image>();

        cursorImage.color = new Color32(255, 255, 255, 255);
        cursorImage.sprite = image;
    }

    public void HideCursorItem()
    {
        var cursorImage = _cursorItem.GetComponent<Image>();

        cursorImage.color = new Color32(255, 255, 255, 0);
        cursorImage.sprite = null;
    }

    public void SpawnItemInGridTile()
    {
        if (_allGridTiles.IndexOf(_currentGridTile) < _allGridTiles.Count - 441)
        {
            var item = Instantiate(_imagePrefabUI, _currentGridTile.transform);
            item.GetComponent<Image>().sprite = _cursorItem.GetComponent<Image>().sprite;
        }
        else
        {
            var item = Instantiate(_imagePrefab, _currentGridTile.transform);
            item.transform.localPosition = new Vector3(0, 0, -1);
            item.GetComponent<SpriteRenderer>().sprite = _cursorItem.GetComponent<Image>().sprite;
        }

    }
}
