using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDragScript : MonoBehaviour
{
    private Vector3 mOffset;

    private void OnMouseDown()
    {
        //Store offset = gameObject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMousePos();
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePoint = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + mOffset;
    }
}
