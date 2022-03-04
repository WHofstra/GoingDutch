using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridClippingObject : MonoBehaviour
{
    [SerializeField] private DraggableObject _draggableObject;
    [SerializeField] private Tilemap _tileMap;

    private Transform parentTransform;

    public void Awake(){
        if (_draggableObject != null)
            _draggableObject.checkTile += CheckTile;

        parentTransform = (transform.parent != null) ?
            transform.parent.GetComponent<Transform>() : transform;
    }

    private void CheckTile(){
        // It checks the tile beneath the sprite
        Vector3Int cellPosition = _tileMap.WorldToCell(parentTransform.position);

        // if (_tileMap.HasTile(cellPosition)){
            parentTransform.position = _tileMap.CellToWorld(cellPosition);
            parentTransform.position += new Vector3(0, _tileMap.cellSize.y * 0.5f, 0);
        // }
        // else {
        //     Debug.Log(cellPosition);
        // }
    }
}
