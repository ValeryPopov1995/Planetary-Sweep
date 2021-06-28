using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShooterEventTrigger : EventTrigger
{
    Vector2 Delta;

    Vector2 lastPos;
    PointerEventData pointer;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        pointer = eventData;
        lastPos = eventData.position;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        pointer = null;
    }

    public Vector2 GetDelta()
    {
        if (pointer == null) return Vector2.zero;
        
        Vector2 v;
        v.x= pointer.position.x - lastPos.x;
        v.y = pointer.position.y - lastPos.y;
        lastPos = pointer.position;
        return v;
    }
}
