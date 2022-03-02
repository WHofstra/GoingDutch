using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour,
    DocumentObject
{
    // Use SerializeField to pass constructor parameters
    [SerializeField] private string _name;
    
    private string id;
    private List<PlaceableAsset> assets;

    // Getters and setters
    public string ID { get { return id; } }
    public List<PlaceableAsset> Assets { get { return assets; } }
}
