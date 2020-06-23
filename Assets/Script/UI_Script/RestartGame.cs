using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject panelMenu;

    public Text scoreNow;   //开始游戏后显示当前积分

    //private Button startGame;
    private bool start;

    private void Awake()
    {
        //startGame = GetComponent<Button>();
        //startGame.onClick.AddListener(OnBtnClick);
        start = false;
    }

    public void OnBtnClick()
    {
        if (start == false)      //第一次开始游戏
        {
            panelMenu.SetActive(false);
            Time.timeScale = 1;
            scoreNow.gameObject.SetActive(true);
            start = true;
        }
        else
            SceneManager.LoadScene(0);
    }
}
