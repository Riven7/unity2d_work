using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNow : MonoBehaviour
{
    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
    }

    public void Show(int score1)
    {
        score.text = "当前积分: " + score1.ToString();
    }

    public void sumScore(int sum)
    {
        score.text = "本局所获积分: " + sum.ToString();
    }
}
