using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    private Text textShow;

    private void Awake()
    {
        textShow = GetComponent<Text>();
    }

    public void ShowInt(int count)
    {
        textShow.text = "持有炸弹：" + count.ToString();
    }

    public void ShowFloat(float health)
    {
        textShow.text = "当前血量：" + health.ToString();
    }
}
