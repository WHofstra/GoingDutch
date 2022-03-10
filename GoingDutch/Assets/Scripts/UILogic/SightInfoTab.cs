using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SightInfoTab : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI sightName;
    [SerializeField] public TextMeshProUGUI distance;
    [SerializeField] public GameObject rewardImage;

    public void PopUp(string place, float dis, Sprite image)
    {
        sightName.text = place;
        distance.text = dis.ToString("F1") + "km";
        rewardImage.GetComponent<Image>().sprite = image;
        rewardImage.GetComponent<Image>()
        if (dis < 1)
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
