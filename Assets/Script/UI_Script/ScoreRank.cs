using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRank : MonoBehaviour
{
    public int PlayerScore = 0;

    private void Awake()
    {
        PlayerScore = 0;

    }

    public void SaveData()
    {
        int[] sort = new int[4];
        int change = 0;
        sort[0] = PlayerScore;
        sort[1] = PlayerPrefs.GetInt("第一名");
        sort[2] = PlayerPrefs.GetInt("第二名");
        sort[3] = PlayerPrefs.GetInt("第三名");

        Debug.Log("准备保存");
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                if (sort[j] > sort[i])
                {
                    change = sort[i];
                    sort[i] = sort[j];
                    sort[j] = change;
                }
            }
        }

        PlayerPrefs.SetInt("第一名", sort[0]);
        PlayerPrefs.SetInt("第二名", sort[1]);
        PlayerPrefs.SetInt("第三名", sort[2]);

        Debug.Log(PlayerScore);

        PlayerScore = 0;
    }
}
