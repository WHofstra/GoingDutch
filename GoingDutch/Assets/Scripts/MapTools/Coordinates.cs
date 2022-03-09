using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public float lat1 = 52.3858025f;
    public float long1 = 4.6375823f;
     public float lat2 = 52.3872693f;
     public float long2 = 4.6387196f;

    public Coordinate coord1 = new Coordinate();
    public Coordinate coord2 = new Coordinate();
    // Start is called before the first frame update
    void Start()
    {
        coord1.latitude = lat1;
        coord1.longitude = long1;
        coord2.latitude = lat2;
        coord2.longitude = long2;
/*        CalcDistanceBetweenTwoCoordinates();
*/    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Coordinate {
    public float latitude;
    public float longitude;

   public Coordinate(float latitude = 0, float longitude = 0)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public Vector3 ConvertToCartesian()
    {
        Vector3 position = new Vector3();

        position.x = Mathf.Cos(latitude * Mathf.Deg2Rad) * Mathf.Cos(longitude * Mathf.Deg2Rad);
        position.y = Mathf.Cos(latitude * Mathf.Deg2Rad) * Mathf.Sin(longitude * Mathf.Deg2Rad);
        position.z = Mathf.Sin(latitude * Mathf.Deg2Rad);

        return position;
    }

    public float rLat()
    {
        return latitude * Mathf.Deg2Rad;
    }
    public float rLong()
    {
        return latitude * Mathf.Deg2Rad;
    }
    public static float CalcDistanceBetweenTwoCoordinates(Coordinate c1, Coordinate c2)
    {

        float d = Vector3.Distance(c1.ConvertToCartesian(), c2.ConvertToCartesian());
        float o1 = d / 2;

        float theta = Mathf.Asin(o1);
        float angleD = theta * 2;

        float distance = angleD * 6357;
        return distance;
    }
}
