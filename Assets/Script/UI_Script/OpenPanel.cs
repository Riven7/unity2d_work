using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject menuPanel;

    //private Button btn;
    //private bool isOpen;

    Dictionary<string, GameObject> panels;

    private void Awake()
    {
        //btn = GetComponent<Button>();
        panels = new Dictionary<string, GameObject>();
        panels.Add(panel.name, panel);
        panels.Add(menuPanel.name, menuPanel);
    }

    public void OnBtnClick()
    {
        ClosePanel(menuPanel.name);
        DkPanel(panel.name);
    }

    public void DkPanel(string name)
    {
        panels[name].SetActive(true);
        Debug.Log(name + " open");
    }

    public void ClosePanel(string name)
    {
        panels[name].SetActive(false);
        Debug.Log(name + " close");
    }
}
