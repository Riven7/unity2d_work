using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    private Text first;

    private void Awake()
    {
        first = GetComponent<Text>();
        updateRank();
    }

    public void updateRank()
    {
        first.text = "第一名: " + PlayerPrefs.GetInt("第一名").ToString();
    }
}
