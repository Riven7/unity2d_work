using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject panel;
    public Button startGame;
    public Button newGame;

    private Button btn;
    private bool isOpen;

    void Awake()
    {
        btn = GetComponent<Button>();
        isOpen = false;
    }

    public void OnBtnClick()
    {
        if (isOpen == false)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            startGame.enabled = false;
            //newGame.enabled = true;
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
        isOpen = !isOpen;
    }
}
