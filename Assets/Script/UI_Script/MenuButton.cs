using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Text scoreNow;   //打开菜单后不显示当前积分

    public GameObject panel;
    public Button pause;
    //public Button startGame;
    //public Button newGame;想通过让某个按钮可否使用来控制在同一位置的两个按钮，但enable失败了

    //private Button btn;
    //private bool isOpen;
    //btn = GetComponent<Button>();不使用监听可不获取当前按钮

    public void OnBtnClick()
    {      
        Time.timeScale = 0;
        panel.SetActive(true);
        scoreNow.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        //startGame.enabled = false;
       //newGame.enabled = true;
    }
}
