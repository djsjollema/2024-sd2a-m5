using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragablePoint : MonoBehaviour
{
    bool isDraggable = false;
    public Color nwColor;

    [SerializeField] private SpriteRenderer sr;
 
 
    void Start()
    {
        
    }

    void Update()
    {
        sr.color = nwColor;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (isDraggable)
        {
            //print(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }

    private void OnMouseDown()
    {
        isDraggable = true;
    }

    private void OnMouseUp()
    {
        isDraggable = false;
    }
}
