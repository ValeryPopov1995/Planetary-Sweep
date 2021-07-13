using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShooterEventTrigger : EventTrigger
{
    Vector2 _delta;
    Vector2 _lastPos;
    PointerEventData _pointer;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        _pointer = eventData;
        _lastPos = eventData.position;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        _pointer = null;
    }

    public Vector2 GetDelta()
    {
        if (_pointer == null) return Vector2.zero;
        
        Vector2 v;
        v.x= _pointer.position.x - _lastPos.x;
        v.y = _pointer.position.y - _lastPos.y;
        _lastPos = _pointer.position;
        return v;
    }
}
