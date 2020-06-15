using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Button gamePause;
    private bool isPause;

    public GameObject panel;

    private void Awake()
    {
        gamePause = GetComponent<Button>();

       // gamePause.onClick.AddListener(OnBtnClick);利用代码监听是否按下按钮，然后执行函数
        isPause = true;
    }

    public void OnBtnClick()
    {
        panel.SetActive(false);
        Time.timeScale = isPause ? 1 : 0;
        isPause = !isPause;
    }
    
    /*private void OnDestroy()
    {
        gamePause.onClick.RemoveListener(OnBtnClick);
    }*/
}
