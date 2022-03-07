using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    // Delegates
    public delegate void GridClippingDelegate();
    public GridClippingDelegate checkTile;
    public GridClippingDelegate savePosition;

    private Transform parentTransform;

    public void Awake(){
        parentTransform = (transform.parent != null) ?
            transform.parent.GetComponent<Transform>() : transform;
    }

    // When player drags this object
    public void OnMouseDrag(){
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = parentTransform.position.z;
        parentTransform.position = newPos;
    }

    public void OnMouseDown(){
        // On the moment the user starts dragging this
        savePosition();
    }

    public void OnMouseUp(){
        checkTile();
    }
}
