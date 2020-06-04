using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    private Text first;
    //public Text PlayerScore;

    private void Awake()
    {
        first = GetComponent<Text>();
    }

    public void updateRank()
    {
        first.text = "第一名: " + PlayerPrefs.GetInt("第一名").ToString();
        //PlayerScore.text = PlayerPrefs.GetInt("第一名").ToString();
    }
}
