using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridClippingObject : MonoBehaviour
{
    // Constant variables
    private const int MINIMUM_COLLIDING_OBJ = 0;

    // Use SerializeField to pass constructor parameters
    [SerializeField] private DraggableObject _draggableObject;
    [SerializeField] private Tilemap _tileMap;

    private Transform parentTransform;
    private Vector3 currentPosition;
    private int objectsItCollidesWith;

    public void Awake(){
        if (_draggableObject != null){
            _draggableObject.checkTile    += CheckTile;
            _draggableObject.savePosition += SavePosition;
        }

        parentTransform = (transform.parent != null) ?
            transform.parent.GetComponent<Transform>() : transform;
        currentPosition       = parentTransform.position;
        objectsItCollidesWith = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer.Equals(ConstantVariables.Layer.placebleAsset)){
            checkAmountOfObjects(objectsItCollidesWith);
            objectsItCollidesWith++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.layer.Equals(ConstantVariables.Layer.placebleAsset)){
            objectsItCollidesWith--;
            checkAmountOfObjects(objectsItCollidesWith);
        }
    }

    private void CheckTile(){
        // It checks the tile beneath the sprite
        if (_tileMap != null &&
            checkAmountOfObjects(objectsItCollidesWith).Equals(MINIMUM_COLLIDING_OBJ))
        {
            Vector3Int cellPosition = _tileMap.WorldToCell(parentTransform.position);
            parentTransform.position = _tileMap.CellToWorld(cellPosition);
            parentTransform.position += new Vector3(0, _tileMap.cellSize.y * 0.5f, 0);
        }
        else
            parentTransform.position = currentPosition;
    }

    private void SavePosition(){
        currentPosition = parentTransform.position;
    }

    private static int checkAmountOfObjects(int amount){
        if (amount < MINIMUM_COLLIDING_OBJ)
            amount = MINIMUM_COLLIDING_OBJ;
        return amount;
    }
}
