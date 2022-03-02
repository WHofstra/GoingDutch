using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableTypeConverter
{
    // Conversion from 'Component'-array to 'Component'-List
    public static List<Component> ToList(Component[] anArray){
        return new List<Component>(anArray);
    }

    // Conversion from 'Component'-array to 'PlaceableAsset'-List
    public static List<PlaceableAsset> ToPlaceableAssetList(Component[] anArray){
        return ToPlaceableAssetList(ToList(anArray));
    }

    // Conversion from 'Component'-list to 'PlaceableAsset'-List
    public static List<PlaceableAsset> ToPlaceableAssetList(List<Component> aList){
        List<PlaceableAsset> assetList = new List<PlaceableAsset>();
        foreach (Component c in aList){
            if (c is PlaceableAsset asset)
                assetList.Add(asset);
        }
        return assetList;
    }

    // Conversion from 'Component'-list to string
    public static string ToString(List<Component> aList){
        string newString = "Size \u0028" + aList.Count + "\u0029\u003A \u007B\n";
        foreach(Component c in aList){
            newString += c.GetType().ToString() + "\n";
        }
        newString += "\u007D";
        return newString;
    }

    // Conversion from 'Component'-array to string
    public static string ToString(Component[] anArray){
        return ToString(ToList(anArray));
    }

    // Conversion from 'PlaceableAsset'-list to string
    public static string ToString(List<PlaceableAsset> aList){
        return "Size \u0028" + aList.Count + "\u0029";
    }
}
