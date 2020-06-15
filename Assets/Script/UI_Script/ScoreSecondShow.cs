using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSecondShow : MonoBehaviour
{
    private Text second;

    private void Awake()
    {
        second = GetComponent<Text>();
        updateRank();
    }

    public void updateRank()
    {
        second.text = "第二名: " + PlayerPrefs.GetInt("第二名").ToString();
    }
}
