using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    // Delegates
    public delegate void GridClippingDelegate();
    public GridClippingDelegate checkTile;

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

    public void OnMouseUp(){
        checkTile();
    }
}
