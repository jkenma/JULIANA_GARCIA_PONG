using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string PointsCount;
    public int puntuacionA = 0;
    public int puntuacionb = 0;
    public TextMeshProUGUI Marcadortext;

    void Start()
    {
        Debug.Log(PointsCount);
    }
    public void UpdatePointsText()
    {
        PointsCount = puntuacionA + "|" + puntuacionb;
        Marcadortext.text=PointsCount;
    }
    
}
