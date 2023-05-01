using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 touchDistance;
    [HideInInspector]
    public Vector2 oldPointer;
    [HideInInspector]
    protected int idPointer;
    [HideInInspector]
    public bool pressed;

    void Update()
    {
        if (pressed)
        {
            if (idPointer >= 0 && idPointer < Input.touches.Length)
            {
                touchDistance = Input.touches[idPointer].position - oldPointer;
                oldPointer = Input.touches[idPointer].position;
            } else
            {
                touchDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - oldPointer;
                oldPointer = Input.mousePosition;
            }
        } else
        {
            touchDistance = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        idPointer = eventData.pointerId;
        oldPointer = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}