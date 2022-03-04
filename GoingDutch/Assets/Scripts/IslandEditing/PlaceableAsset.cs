using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableAsset : MonoBehaviour
{
    // Use SerializeField to pass constructor parameters
    [SerializeField] private int _value = 0;

    private string id;

    // Getters and setters
    public string ID { get { return id; } }
    public int Value { get { return _value; } }
}
