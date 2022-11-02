using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public Color32 currentColor;
    [SerializeField] public bool currentTile;

    [SerializeField] public bool haveItem;
    [SerializeField] public List<GameObject> eqipmentItems;

    [SerializeField] private SpriteRenderer _spriterenderer;

    private GridTileManager _manager;
    private ItemManager _itemManager;



    void Awake()
    {
        currentTile = false;
        _manager = this.transform.parent.GetComponent<GridTileManager>();
        _itemManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ItemManager>();
    }
    void Update()
    {
        CheckEcquipments();

        _spriterenderer.color = currentColor;


        _manager.currentTile[id] = currentTile;


        if (currentTile == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    private void CheckEcquipments()
    {
        haveItem = this.transform.childCount > 1;

        eqipmentItems.Clear();
        for (int i = 1; i < this.transform.childCount; i++)
        {
            eqipmentItems.Add(this.transform.GetChild(i).gameObject);
        }
    }


    public void OnMouseDown()
    {
        if (haveItem == false) { return; }

        _itemManager.DisplayCursorItem(this.transform.GetChild(this.transform.childCount - 1).GetComponent<SpriteRenderer>().sprite);

        Destroy(this.transform.GetChild(this.transform.childCount - 1).gameObject);
    }

    public void OnMouseUp()
    {
        if (_itemManager._cursorItem.GetComponent<CursorItem>().haveItem == false) { return; }

        _itemManager.SpawnItemInGridTile();
        _itemManager.HideCursorItem();
    }


    private void OnMouseEnter()
    {
        currentTile = true;
    }
    private void OnMouseExit()
    {
        currentTile = false;
    }


}
