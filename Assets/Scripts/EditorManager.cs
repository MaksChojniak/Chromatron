using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public static bool s_editorOpened = true;

    [SerializeField] private List<GameObject> _editorGameObjects;

    [SerializeField] private bool _start = false;
    [SerializeField] private bool _hide = false;
    [SerializeField] private bool _display = false;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    void Update()
    {
        //print(s_editorOpened);

        if(_start == true)
        {
            GetAllObjects();
            _start = false;
        }

        if (_hide == true)
        {
            if (s_editorOpened == true)
            {
                HideEditor();
                s_editorOpened = false;
            }
            _hide = false;
        }

        if (_display == true)
        {
            if (s_editorOpened == false)
            {
                DisplayEditor();
                s_editorOpened = true;
            }
            _display = false;
        }
    }


    private void GetAllObjects()
    {
        List<GameObject> objects = new List<GameObject>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Editor"))
        {
            objects.Add(obj);
        }

        _editorGameObjects = objects;
    }

    private void HideEditor()
    {
        for(int i = 0; i <_editorGameObjects.Count; i++)
        {
            RectTransform normalRectTransform = _editorGameObjects[i].transform.parent.GetChild(_editorGameObjects[i].transform.parent.childCount - 2).GetComponent<RectTransform>();
            normalRectTransform.localPosition += new Vector3(45, 0, 0);
            normalRectTransform.sizeDelta = new Vector2(normalRectTransform.sizeDelta.x * 1.25f, normalRectTransform.sizeDelta.y);

            RectTransform currentRectTransform = _editorGameObjects[i].transform.parent.GetChild(_editorGameObjects[i].transform.parent.childCount - 3).GetComponent<RectTransform>();
            currentRectTransform.localPosition += new Vector3(15, 0, 0);
            currentRectTransform.sizeDelta = new Vector2(currentRectTransform.sizeDelta.x * 1.25f, currentRectTransform.sizeDelta.y);


            _editorGameObjects[i].SetActive(false);
        }
    }


    private void DisplayEditor()
    {
        for (int i = 0; i < _editorGameObjects.Count; i++)
        {
            RectTransform normalRectTransform = _editorGameObjects[i].transform.parent.GetChild(_editorGameObjects[i].transform.parent.childCount - 2).GetComponent<RectTransform>();
            normalRectTransform.localPosition -= new Vector3(45, 0, 0);
            normalRectTransform.sizeDelta = new Vector2(normalRectTransform.sizeDelta.x * 0.8f, normalRectTransform.sizeDelta.y);

            RectTransform currentRectTransform = _editorGameObjects[i].transform.parent.GetChild(_editorGameObjects[i].transform.parent.childCount - 3).GetComponent<RectTransform>();
            currentRectTransform.localPosition -= new Vector3(15, 0, 0);
            currentRectTransform.sizeDelta = new Vector2(currentRectTransform.sizeDelta.x * 0.8f, currentRectTransform.sizeDelta.y);


            _editorGameObjects[i].SetActive(true);
        }
    }


}
