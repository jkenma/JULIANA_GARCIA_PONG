using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public string PointsCount;
    public int p1 = 0;
    public int p2 = 0;
    public TextMeshProUGUI Marcadortext;

    void Start()
    {
        Debug.Log(PointsCount);
        
    }
    public void UpdatePointsText()
    {
        PointsCount = p1 + "|" + p2;
        Marcadortext.text=PointsCount;
    }
}
