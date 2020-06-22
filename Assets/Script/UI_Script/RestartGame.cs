using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject panelMenu;

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
            start = true;
        }
        else
            SceneManager.LoadScene(0);
    }
}
