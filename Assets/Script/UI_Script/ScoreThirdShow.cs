using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreThirdShow : MonoBehaviour
{
    private Text third;

    private void Awake()
    {
        third = GetComponent<Text>();
    }

    public void updateRank()
    {
        third.text = "第三名: " + PlayerPrefs.GetInt("第三名").ToString();
    }
}
