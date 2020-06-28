using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNow : MonoBehaviour
{
    private Text score;

    private Spawner alterSpawnTime;

    private void Awake()
    {
        score = GetComponent<Text>();
        alterSpawnTime = GameObject.Find("spawner").GetComponent<Spawner>();
    }

    public void Show(int score1)
    {
        score.text = "当前积分: " + score1.ToString();
        if (score1 >= 3000)
        {
            alterSpawnTime.spawnTime = 1f;
            //Debug.Log(alterSpawnTime.spawnTime); 
        }
    }

    public void sumScore(int sum)
    {
        score.text = "本局所获积分: " + sum.ToString();
    }
}
