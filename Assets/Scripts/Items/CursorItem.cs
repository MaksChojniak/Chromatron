using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorItem : MonoBehaviour
{
    public Canvas parentCanvas;
    public bool haveItem;

    void Start()
    {
        
    }

    void Update()
    {

        if (GetComponent<Image>().sprite == null || GetComponent<Image>().color == new Color32(255, 255, 255, 0))
        { 
            haveItem = false;
        }
        else
        {
            haveItem = true;
        }

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

        transform.position = mousePos;
    }
}
