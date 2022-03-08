using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridClippingObject : MonoBehaviour
{
    // Constant variables
    private const int MINIMUM_COLLIDING_OBJ = 0;
    private const int TILEMAP_Z_AXIS        = 0;

    // Use SerializeField to pass constructor parameters
    [SerializeField] private DraggableObject _draggableObject;
    [SerializeField] private Tilemap _tileMap;

    private Transform parentTransform;
    private Vector3 currentPosition;
    private int objectsItCollidesWith;

    public void Awake(){
        if (_draggableObject != null){
            _draggableObject.checkTile += CheckTile;
            _draggableObject.savePosition += SavePosition;
        }
    }

    public void Start(){
        parentTransform =
           (_draggableObject != null &&
            _draggableObject.ParentTransform != null) ?
            _draggableObject.ParentTransform :
            transform;

        currentPosition = parentTransform.position;
        objectsItCollidesWith = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        // Add to amount of objects it comes in contact with
        if (collision.gameObject.layer.Equals(ConstantVariables.Layer.placebleAsset)){
            objectsItCollidesWith = CheckAmountOfObjects(objectsItCollidesWith);
            objectsItCollidesWith++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        // Subtract from amount of objects it comes in contact with
        if (collision.gameObject.layer.Equals(ConstantVariables.Layer.placebleAsset)){
            objectsItCollidesWith--;
            objectsItCollidesWith = CheckAmountOfObjects(objectsItCollidesWith);
        }
    }

    // Override this function with a 'true' return to allow for water placement
    protected bool DoesTileExist(Vector3Int coordinates){
        if (_tileMap != null &&
            _tileMap.GetTile(coordinates) != null)
            return true;
        return false;
    }

    private void CheckTile(){
        // It checks the tile beneath the sprite
        if (_tileMap != null &&
            CheckAmountOfObjects(objectsItCollidesWith).Equals(MINIMUM_COLLIDING_OBJ))
        {
            Vector3Int cellPosition  = _tileMap.WorldToCell(parentTransform.position);
            if (DoesTileExist(new Vector3Int(cellPosition.x, cellPosition.y, TILEMAP_Z_AXIS)))
            {
                // Keep the z-axis the same value
                Vector3 objectCenter = _tileMap.GetCellCenterWorld(cellPosition);
                Vector3 newPosition  = new Vector3(objectCenter.x, objectCenter.y, parentTransform.position.z);
                parentTransform.position = newPosition;
            }
            else
                parentTransform.position = currentPosition;
        }
        else
            parentTransform.position = currentPosition;
    }

    private void SavePosition(){
        currentPosition = parentTransform.position;
    }

    private static int CheckAmountOfObjects(int amount){
        // Prevent it from reaching below zero
        if (amount < MINIMUM_COLLIDING_OBJ)
            amount = MINIMUM_COLLIDING_OBJ;
        return amount;
    }
}
