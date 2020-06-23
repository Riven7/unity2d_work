using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    //private Button gamePause;
    //private bool isPause;

    public GameObject panel;
    public Text scoreNow;   ////游戏中才显示当前积分

    private void Awake()
    {
        //gamePause = GetComponent<Button>();

       // gamePause.onClick.AddListener(OnBtnClick);利用代码监听是否按下按钮，然后执行函数
       // isPause = true;
    }

    public void OnBtnClick()
    {
        panel.SetActive(false);
        //Time.timeScale = isPause ? 1 : 0;
        Time.timeScale = 1;
        //isPause = !isPause;
        scoreNow.gameObject.SetActive(true);
    }
    
    /*private void OnDestroy()
    {
        gamePause.onClick.RemoveListener(OnBtnClick);
    }*/
}
