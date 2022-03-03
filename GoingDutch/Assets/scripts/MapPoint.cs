using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    [SerializeField] public float latitude;
    [SerializeField] public float longitude;
    [SerializeField] public GameObject pointBottom;
    [SerializeField] public GameObject pointTop;
    [SerializeField] public bool trackDistance = false;
    [SerializeField] public MapPoint tracker;
    private Vector2 bottomCoord = new Vector2(50.62853391914265f, 3.073552403615819f);
    private Vector2 topCoord = new Vector2(53.73164920488342f, 7.261044644070169f);
    private float mapHeight;
    private float mapWidth;
    // Start is called before the first frame update
    void Start()
    {
        mapHeight = pointTop.transform.position.y - pointBottom.transform.position.y;
        mapWidth = pointTop.transform.position.x - pointBottom.transform.position.x;
        gameObject.transform.position = new Vector2(((longitude - bottomCoord.y) / (topCoord.y - bottomCoord.y)) *mapWidth, ((latitude - bottomCoord.x) / (topCoord.x - bottomCoord.x)) * mapHeight);
        gameObject.transform.position = gameObject.transform.position + pointBottom.transform.position;

        if (trackDistance)
        {
            Coordinate trackCoord = new Coordinate(tracker.latitude, tracker.longitude);
            Coordinate myPos = new Coordinate(latitude, longitude);
            Debug.Log(Coordinate.CalcDistanceBetweenTwoCoordinates(myPos, trackCoord));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
