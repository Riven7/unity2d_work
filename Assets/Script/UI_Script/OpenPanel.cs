using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;

    private Button btn;
    private bool isOpen;

    Dictionary<string, GameObject> panels;

    private void Awake()
    {
        btn = GetComponent<Button>();
        panels = new Dictionary<string, GameObject>();
        panels.Add(panel.name, panel);
        isOpen = false;
    }

    public void OnBtnClick()
    {
        if (isOpen == false)
            DkPanel(panel.name);
        else
            ClosePanel(panel.name);
        isOpen = !isOpen;
    }

    public void DkPanel(string name)
    {
        panels[name].SetActive(true);
    }

    public void ClosePanel(string name)
    {
        panels[name].SetActive(false);
    }
}
