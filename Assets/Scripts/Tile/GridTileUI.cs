using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridTileUI : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public Color32 currentColor;
    [SerializeField] public bool currentTile;

    [SerializeField] public bool haveItem;
    [SerializeField] public List<GameObject> eqipmentItems;

    [SerializeField] private Image _image;

    private GridTileManagerUI _manager;
    private ItemManager _itemManager;

    void Awake()
    {

        currentTile = false;
        _manager = this.transform.parent.GetComponent<GridTileManagerUI>();

        _itemManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ItemManager>();
    }
    void Update()
    {
        CheckEcquipments();

        _image.color = currentColor;


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
            //if (eqipmentItems.Count + 1 == this.transform.childCount)
                eqipmentItems.Add(this.transform.GetChild(i).gameObject);
        }
    }



    public void IfMouseDown()
    {
        if(haveItem == false) { return; }

        _itemManager.DisplayCursorItem(this.transform.GetChild(this.transform.childCount - 1).GetComponent<Image>().sprite);

        Destroy(this.transform.GetChild(this.transform.childCount - 1).gameObject);
    }

    public void IfMouseDrag()
    {
        if (!haveItem) { return; }

        //_itemManager.DisplayCursorItem(this.transform.GetChild(this.transform.childCount - 1).GetComponent<Image>().sprite);

        //Destroy(this.transform.GetChild(this.transform.childCount - 1).gameObject);
    }

    public void IfMouseUp()
    {
        if( _itemManager._cursorItem.GetComponent<CursorItem>().haveItem == false) { return; }

        _itemManager.SpawnItemInGridTile();
        _itemManager.HideCursorItem();
    }


    public void IfMouseEnter()
    {
        currentTile = true;
    }
    public void IfMouseExit()
    {
        currentTile = false;
    }
}
