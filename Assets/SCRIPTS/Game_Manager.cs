using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public string PointsCount;
    public int p1 = 0;
    public int p2 = 0;
    public int PointsWin = 5;
    public TextMeshProUGUI Marcadortext;

    public GameObject winPanel;
    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log(PointsCount);


    }
    public void UpdatePointsText()
    {
        PointsCount = p1 + "|" + p2;
        Marcadortext.text = PointsCount;

        if (p1 >= PointsWin || p2 >= PointsWin)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
}
