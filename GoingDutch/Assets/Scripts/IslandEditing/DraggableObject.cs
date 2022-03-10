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
    private SpriteRenderer spriteRenderer;

    // Getters and setters
    public Transform ParentTransform { get { return parentTransform; } }
    public SpriteRenderer SpriteRenderer { get { return spriteRenderer; } }

    public void Awake(){
        parentTransform = (transform.parent != null) ?
            transform.parent.GetComponent<Transform>() : transform;
        spriteRenderer = (GetComponent<SpriteRenderer>() != null) ?
            GetComponent<SpriteRenderer>() : null;
    }

    public void Start(){
        checkTile();
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
