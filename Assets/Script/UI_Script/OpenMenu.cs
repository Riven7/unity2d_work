using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject menuPanel;

    public void OnBtnClick()
    {
        menuPanel.SetActive(true);
        panel.SetActive(false);
    }
}
