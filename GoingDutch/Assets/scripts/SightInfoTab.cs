using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SightInfoTab : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI sightName;
    [SerializeField] public TextMeshProUGUI distance;

    public void PopUp(string place, float dis)
    {
        sightName.text = place;
        distance.text = dis.ToString("F1") + "km";
        if(dis < 1)
        {
            dis = dis * 1000;
            dis = Mathf.Round(dis);
            distance.text = dis.ToString() + "m";
        }
        gameObject.SetActive(true);
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
}
